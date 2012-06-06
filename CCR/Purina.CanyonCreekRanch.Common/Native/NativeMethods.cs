using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;


namespace Purina.CanyonCreekRanch.Common.Native
{
  public static class NativeMethods
  {
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct LOCALGROUP_MEMBERS_INFO_2
    {
      public int lgrmi2_sid;
      public int lgrmi2_sidusage;
      public string lgrmi2_domainandname;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct LOCALGROUP_USERS_INFO_0
    {
      public string groupname;
    }

    [DllImport("ADVAPI32.dll", EntryPoint = "LogonUserW", SetLastError = true, CharSet = CharSet.Unicode)]
    private static extern bool LogonUser(string lpszUsername, string lpszDomain, string lpszPassword, int dwLogonType, int dwLogonProvider, ref IntPtr phToken);
    [DllImport("KERNEL32.dll", CharSet = CharSet.Unicode)]
    private static extern bool CloseHandle(IntPtr handle);
    [DllImport("NetAPI32.dll", CharSet = CharSet.Unicode)]
    private extern static int NetLocalGroupGetMembers(
        [MarshalAs(UnmanagedType.LPWStr)] string servername,
        [MarshalAs(UnmanagedType.LPWStr)] string localgroupname,
        int level,
        out IntPtr bufptr,
        int prefmaxlen,
        out int entriesread,
        out int totalentries,
        IntPtr resume_handle);
    [DllImport("Netapi32.dll", SetLastError = true)]
    private extern static int NetUserGetLocalGroups
        ([MarshalAs(UnmanagedType.LPWStr)] string servername,
         [MarshalAs(UnmanagedType.LPWStr)] string username,
         int level,
         int flags,
         out IntPtr bufptr,
         int prefmaxlen,
         out int entriesread,
         out int totalentries);
    [DllImport("Netapi32.dll", SetLastError = true)]
    private static extern int NetApiBufferFree(IntPtr Buffer);

    public static bool Logon(string userName, string domain, string password)
    {
      IntPtr token = IntPtr.Zero;
      bool result = LogonUser(userName, domain, password, 2, 0, ref token);

      if (token != IntPtr.Zero)
        CloseHandle(token);

      return result;
    }

    public static List<string> GetGroupUsers(string groupName)
    {
      List<string> myList = new List<string>();
      int EntriesRead;
      int TotalEntries;
      IntPtr Resume = IntPtr.Zero;
      IntPtr buffer;
      
      int val = NetLocalGroupGetMembers(null, groupName, 2, out buffer, -1, out EntriesRead, out TotalEntries, Resume);
      do
      {
        if (EntriesRead > 0)
        {
          LOCALGROUP_MEMBERS_INFO_2[] Members = new LOCALGROUP_MEMBERS_INFO_2[EntriesRead];
          IntPtr iter = buffer;
          for (int i = 0; i < EntriesRead; i++)
          {
            Members[i] = (LOCALGROUP_MEMBERS_INFO_2)Marshal.PtrToStructure(iter, typeof(LOCALGROUP_MEMBERS_INFO_2));
            iter = (IntPtr)((int)iter + Marshal.SizeOf(typeof(LOCALGROUP_MEMBERS_INFO_2)));
            myList.Add(Members[i].lgrmi2_domainandname);
          }
          NetApiBufferFree(buffer);
        }
      } while (val != 0 && (val = NetLocalGroupGetMembers(null, groupName, 2, out buffer, -1, out EntriesRead, out TotalEntries, Resume)) == 234);

      return myList;
    }

    public static List<string> GetUserGroups(string userName)
    {
      List<string> myList = new List<string>();
      int EntriesRead;
      int TotalEntries;
      IntPtr bufPtr;

      int ErrorCode = NetUserGetLocalGroups(null, userName, 0, 0, out bufPtr, 1024, out EntriesRead, out TotalEntries);

      do
      {
        if (EntriesRead > 0)
        {
          LOCALGROUP_USERS_INFO_0[] RetGroups = new LOCALGROUP_USERS_INFO_0[EntriesRead];
          IntPtr iter = bufPtr;
          for (int i = 0; i < EntriesRead; i++)
          {
            RetGroups[i] = (LOCALGROUP_USERS_INFO_0)Marshal.PtrToStructure(iter, typeof(LOCALGROUP_USERS_INFO_0));
            iter = (IntPtr)((int)iter + Marshal.SizeOf(typeof(LOCALGROUP_USERS_INFO_0)));
            myList.Add(RetGroups[i].groupname);
          }
          NetApiBufferFree(bufPtr);
        }
      } while (ErrorCode != 0 && (ErrorCode = NetUserGetLocalGroups(null, userName, 0, 0, out bufPtr, 1024, out EntriesRead, out TotalEntries)) == 234);
      return myList;
    }
  }
}
