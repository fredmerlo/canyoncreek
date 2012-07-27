using System;
using System.Runtime.InteropServices;


namespace Purina.CanyonCreekRanch.Common.Native
{
  public static class NativeMethods
  {
    [DllImport("ADVAPI32.dll", EntryPoint = "LogonUserW", SetLastError = true, CharSet = CharSet.Unicode)]
    private static extern bool LogonUser(string lpszUsername, string lpszDomain, string lpszPassword, int dwLogonType, int dwLogonProvider, ref IntPtr phToken);
    [DllImport("KERNEL32.dll", CharSet = CharSet.Unicode)]
    private static extern bool CloseHandle(IntPtr handle);

    public static bool Logon(string userName, string domain, string password)
    {
      IntPtr token = IntPtr.Zero;
      bool result = LogonUser(userName, domain, password, 2, 0, ref token);

      if (token != IntPtr.Zero)
        CloseHandle(token);

      return result;
    }
  }
}
