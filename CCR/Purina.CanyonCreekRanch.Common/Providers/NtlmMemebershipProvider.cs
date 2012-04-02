using System.Web.Security;
using System.Configuration.Provider;
using System.Collections.Specialized;
using System;
using System.Data;
using System.Data.Odbc;
using System.Configuration;
using System.Diagnostics;
using System.Web;
using System.Globalization;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Web.Configuration;
using System.Runtime.InteropServices;

namespace Purina.CanyonCreekRanch.Common.Providers
{

  public sealed class NtlmMembershipProvider : MembershipProvider
  {
    [DllImport("ADVAPI32.dll", EntryPoint = "LogonUserW", SetLastError = true, CharSet = CharSet.Auto)]
    public static extern bool LogonUser(string lpszUsername, string lpszDomain, string lpszPassword, int dwLogonType, int dwLogonProvider, ref IntPtr phToken);
    [DllImport("ADVAPI32.dll", SetLastError = true, CharSet = CharSet.Auto)]
    public static extern int DuplicateToken(IntPtr hToken,int impersonationLevel,ref IntPtr hNewToken);
    [DllImport("ADVAPI32.dll", SetLastError = true, CharSet = CharSet.Auto)]
    public static extern bool RevertToSelf();
    [DllImport("KERNEL32.dll", CharSet = CharSet.Auto)]
    public static extern bool CloseHandle(IntPtr handle);

    private int newPasswordLength = 8;
    private string eventSource = "NtlmMembershipProvider";
    private string eventLog = "Application";
    private string exceptionMessage = "An exception occurred. Please check the Event Log.";
    private string connectionString;
    private MachineKeySection machineKey;
    private bool writeExceptionsToEventLog;

    public bool WriteExceptionsToEventLog
    {
      get { return writeExceptionsToEventLog; }
      set { writeExceptionsToEventLog = value; }
    }

    public override void Initialize(string name, NameValueCollection config)
    {
      if (config == null)
        throw new ArgumentNullException("config");

      if (name == null || name.Length == 0)
        name = "NtlmMembershipProvider";

      if (String.IsNullOrEmpty(config["description"]))
      {
        config.Remove("description");
        config.Add("description", "NTLM Membership provider");
      }

      base.Initialize(name, config);

      applicationName = GetConfigValue(config["applicationName"], System.Web.Hosting.HostingEnvironment.ApplicationVirtualPath);
      maxInvalidPasswordAttempts = Convert.ToInt32(GetConfigValue(config["maxInvalidPasswordAttempts"], "5"));
      passwordAttemptWindow = Convert.ToInt32(GetConfigValue(config["passwordAttemptWindow"], "10"));
      minRequiredNonAlphanumericCharacters = Convert.ToInt32(GetConfigValue(config["minRequiredNonAlphanumericCharacters"], "1"));
      minRequiredPasswordLength = Convert.ToInt32(GetConfigValue(config["minRequiredPasswordLength"], "7"));
      passwordStrengthRegularExpression = Convert.ToString(GetConfigValue(config["passwordStrengthRegularExpression"], ""));
      enablePasswordReset = Convert.ToBoolean(GetConfigValue(config["enablePasswordReset"], "false"));
      enablePasswordRetrieval = Convert.ToBoolean(GetConfigValue(config["enablePasswordRetrieval"], "false"));
      requiresQuestionAndAnswer = Convert.ToBoolean(GetConfigValue(config["requiresQuestionAndAnswer"], "false"));
      requiresUniqueEmail = Convert.ToBoolean(GetConfigValue(config["requiresUniqueEmail"], "true"));
      writeExceptionsToEventLog = Convert.ToBoolean(GetConfigValue(config["writeExceptionsToEventLog"], "false"));

      string temp_format = GetConfigValue(config["passwordFormat"], "Clear");
      switch (temp_format)
      {
        case "Hashed":
          passwordFormat = MembershipPasswordFormat.Hashed;
          break;
        case "Encrypted":
          passwordFormat = MembershipPasswordFormat.Encrypted;
          break;
        case "Clear":
          passwordFormat = MembershipPasswordFormat.Clear;
          break;
        default:
          throw new ProviderException("Password format not supported.");
      }

      //// Get encryption and decryption key information from the configuration.
      //Configuration cfg = WebConfigurationManager.OpenWebConfiguration(System.Web.Hosting.HostingEnvironment.ApplicationVirtualPath);
      //machineKey = (MachineKeySection)cfg.GetSection("system.web/machineKey");

      //if (machineKey.ValidationKey.Contains("AutoGenerate"))
      //  if (PasswordFormat != MembershipPasswordFormat.Clear)
      //    throw new ProviderException("Hashed or Encrypted passwords " +
      //                                "are not supported with auto-generated keys.");
    }


    private string GetConfigValue(string configValue, string defaultValue)
    {
      if (String.IsNullOrEmpty(configValue))
        return defaultValue;

      return configValue;
    }


    private string applicationName;
    private bool enablePasswordReset;
    private bool enablePasswordRetrieval;
    private bool requiresQuestionAndAnswer;
    private bool requiresUniqueEmail;
    private int maxInvalidPasswordAttempts;
    private int passwordAttemptWindow;
    private MembershipPasswordFormat passwordFormat;

    public override string ApplicationName
    {
      get { return applicationName; }
      set { applicationName = value; }
    }

    public override bool EnablePasswordReset
    {
      get { return enablePasswordReset; }
    }


    public override bool EnablePasswordRetrieval
    {
      get { return enablePasswordRetrieval; }
    }


    public override bool RequiresQuestionAndAnswer
    {
      get { return requiresQuestionAndAnswer; }
    }


    public override bool RequiresUniqueEmail
    {
      get { return requiresUniqueEmail; }
    }


    public override int MaxInvalidPasswordAttempts
    {
      get { return maxInvalidPasswordAttempts; }
    }


    public override int PasswordAttemptWindow
    {
      get { return passwordAttemptWindow; }
    }


    public override MembershipPasswordFormat PasswordFormat
    {
      get { return passwordFormat; }
    }

    private int minRequiredNonAlphanumericCharacters;

    public override int MinRequiredNonAlphanumericCharacters
    {
      get { return minRequiredNonAlphanumericCharacters; }
    }

    private int minRequiredPasswordLength;

    public override int MinRequiredPasswordLength
    {
      get { return minRequiredPasswordLength; }
    }

    private string passwordStrengthRegularExpression;

    public override string PasswordStrengthRegularExpression
    {
      get { return passwordStrengthRegularExpression; }
    }

    public override bool ChangePassword(string username, string oldPwd, string newPwd)
    {
      throw new NotSupportedException("Password reset is not enabled.");
    }

    public override bool ChangePasswordQuestionAndAnswer(string username,
                  string password,
                  string newPwdQuestion,
                  string newPwdAnswer)
    {
      throw new NotSupportedException("Password reset is not enabled.");
    }

    public override MembershipUser CreateUser(string username,
             string password,
             string email,
             string passwordQuestion,
             string passwordAnswer,
             bool isApproved,
             object providerUserKey,
             out MembershipCreateStatus status)
    {
      throw new NotSupportedException("Create user is not enabled.");
    }

    public override bool DeleteUser(string username, bool deleteAllRelatedData)
    {
      throw new NotSupportedException("Delete user is not enabled.");
    }

    public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
    {
      throw new NotSupportedException("Get all users is not enabled.");
    }

    public override int GetNumberOfUsersOnline()
    {

      throw new NotSupportedException("Get number of online users is not enabled.");
    }

    public override string GetPassword(string username, string answer)
    {
      throw new NotSupportedException("Get password is not enabled.");
    }

    public override MembershipUser GetUser(string username, bool userIsOnline)
    {
      throw new NotSupportedException("Get user is not enabled.");
    }

    public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
    {
      throw new NotSupportedException("Get user is not enabled.");
    }

    public override bool UnlockUser(string username)
    {
      throw new NotSupportedException("Unlock user is not enabled.");
    }

    public override string GetUserNameByEmail(string email)
    {
      throw new NotSupportedException("Get user name by email is not enabled.");
    }

    public override string ResetPassword(string username, string answer)
    {
        throw new NotSupportedException("Password reset is not enabled.");
    }

    public override void UpdateUser(MembershipUser user)
    {
      throw new NotSupportedException("Update user is not enabled.");
    }

    public override bool ValidateUser(string username, string password)
    {
      string domainName = GetDomainName(username);
      string userName = GetUsername(username);
      IntPtr token = IntPtr.Zero;
      bool result = false;

      if (RevertToSelf())
      {
        if (LogonUser(userName, domainName, password, 2, 0, ref token))
        {
          if(WindowsIdentity.Impersonate(token) != null)
          {
            result = true;
          }
        }
      }

      if (token != IntPtr.Zero)
        CloseHandle(token);

      return result;
    }

    public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
    {

      throw new NotSupportedException("Find user by name is not enabled.");
    }

    public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
    {
      throw new NotSupportedException("Find user by email is not enabled.");
    }


    public static string GetDomainName(string usernameDomain)
    {
      if (string.IsNullOrEmpty(usernameDomain))
      {
        throw (new ArgumentException("Argument can't be null.", "usernameDomain"));
      }
      if (usernameDomain.Contains("\\"))
      {
        int index = usernameDomain.IndexOf("\\");
        return usernameDomain.Substring(0, index);
      }
      else if (usernameDomain.Contains("@"))
      {
        int index = usernameDomain.IndexOf("@");
        return usernameDomain.Substring(index + 1);
      }
      else
      {
        return "";
      }
    }

    public static string GetUsername(string usernameDomain)
    {
      if (string.IsNullOrEmpty(usernameDomain))
      {
        throw (new ArgumentException("Argument can't be null.", "usernameDomain"));
      }
      if (usernameDomain.Contains("\\"))
      {
        int index = usernameDomain.IndexOf("\\");
        return usernameDomain.Substring(index + 1);
      }
      else if (usernameDomain.Contains("@"))
      {
        int index = usernameDomain.IndexOf("@");
        return usernameDomain.Substring(0, index);
      }
      else
      {
        return usernameDomain;
      }
    } 

    private void WriteToEventLog(Exception e, string action)
    {
      EventLog log = new EventLog();
      log.Source = eventSource;
      log.Log = eventLog;

      string message = "An exception occurred communicating with the data source.\n\n";
      message += "Action: " + action + "\n\n";
      message += "Exception: " + e.ToString();

      log.WriteEntry(message);
    }

  }
}