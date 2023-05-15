using DevExpress.Utils;
using Microsoft.AspNet.Identity;
using PIAdvisingApp.Models;
using PIAdvisingApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace PIAdvisingApp.Service
{
    public class UserService
    {
        public List<SysUser> GetAllSysUsers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var result = ctx.Database
                    .SqlQuery<SysUser>("SELECT * FROM dbo.SysUserInfo ")
                    .ToList();

                return result;
            }
        }

        public SysUser Login(string userName, string password)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var result = ctx.Database
                    .SqlQuery<SysUser>("SELECT * FROM dbo.SysUserInfo WHERE UserName =@UserName and UserPWD = @Password",
                        new SqlParameter("UserName", userName),
                        new SqlParameter("Password", password)
                    )
                    .FirstOrDefault();
                return result;
            }
        }

        public SysUser GetUserId(string userId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var result = ctx.Database
                   .SqlQuery<SysUser>("SELECT * FROM dbo.SysUserInfo WHERE UserName = @UserName",
                       new SqlParameter("UserName", userId)
                   )
                   .FirstOrDefault();
                return result;
            }
        }
    }
}