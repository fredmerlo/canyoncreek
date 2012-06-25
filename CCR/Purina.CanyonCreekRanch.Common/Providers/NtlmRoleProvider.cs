using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;

using Purina.CanyonCreekRanch.Common.Native;

namespace Purina.CanyonCreekRanch.Common.Providers
{
  public class NtlmRoleProvider : RoleProvider
  {
    public override string[] GetRolesForUser(string username)
    {
      return NativeMethods.GetUserGroups(username).ToArray();
    }

    public override string[] GetUsersInRole(string roleName)
    {
      return NativeMethods.GetGroupUsers(roleName).ToArray(); ;
    }

    public override bool IsUserInRole(string username, string roleName)
    {
      return NativeMethods.GetUserGroups(username).Contains(roleName);
    }

    public override string ApplicationName { get; set; }

    public override void AddUsersToRoles(string[] usernames, string[] roleNames)
    {
      throw new NotImplementedException();
    }

    public override void CreateRole(string roleName)
    {
      throw new NotImplementedException();
    }

    public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
    {
      throw new NotImplementedException();
    }

    public override string[] FindUsersInRole(string roleName, string usernameToMatch)
    {
      throw new NotImplementedException();
    }

    public override string[] GetAllRoles()
    {
      throw new NotImplementedException();
    }

    public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
    {
      throw new NotImplementedException();
    }

    public override bool RoleExists(string roleName)
    {
      throw new NotImplementedException();
    }
  }
}
