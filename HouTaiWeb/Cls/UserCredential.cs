using BT.Model;
using BT.Common.Helper;
using Microsoft.Extensions.Options;

namespace HouTaiWeb.Cls
{
    public class UserCredential
    {
        protected string SessionName= ConfigurationService.GetConfigValue("SessionName");


        #region 方法
        public static void SetSession(CookieCredential model)
        {
            if (model != null)
            {
                var sessionName = ConfigurationService.GetConfigValue("SessionName");
                HttpContext.Current.Session.Set<CookieCredential>(sessionName, model);
            }
        }

        public static void GetSession()
        {
            var s = ConfigurationService.GetConfigValue("SessionName");
            var m = HttpContext.Current.Session.Get<CookieCredential>(s);

        }

        //public void SetSession(AdminViewModel model)
        //{
        //    if (model != null)
        //    {
        //        MembershipManager.AdminSN.AdminId = model.id;
        //        MembershipManager.AdminSN.LoginName = model.Login_Name;
        //        MembershipManager.AdminSN.Role = model.Authority;
        //        MembershipManager.AdminSN.RoleName = model.Role_Name;
        //        MembershipManager.AdminSN.Platform = model.Platform;
        //        MembershipManager.AdminSN.AdminType = (int)model.AdminType;
        //    }
        //}
        ///// <summary>
        ///// 删除用户Cookie
        ///// </summary>
        //public void CookieAbandon()
        //{
        //    HttpContext.Current.Response.Cookies[GlobalConfig.AdminCookie].Values["adminid"] = "0";
        //    HttpContext.Current.Response.Cookies[GlobalConfig.AdminCookie].Values["loginname"] = "";
        //    HttpContext.Current.Response.Cookies[GlobalConfig.AdminCookie].Values["password"] = "";
        //}
        ///// <summary>
        ///// 删除用户Session
        ///// </summary>
        //public void SessionAbandon()
        //{
        //    MembershipManager.AdminSN.AdminId = 0;
        //    MembershipManager.AdminSN.Role = string.Empty;
        //    MembershipManager.AdminSN.LoginName = string.Empty;
        //    MembershipManager.AdminSN.RoleName = string.Empty;
        //    MembershipManager.AdminSN.Platform = 0;
        //    MembershipManager.AdminSN.AdminType = 0;
        //}
        ///// <summary>
        ///// 判断用户是否有权限
        ///// </summary>
        ///// <param name="needRole"></param>
        ///// <returns></returns>
        //public bool HasRole(string needRole)
        //{
        //    if (this.IsLogin())
        //    {
        //        if (!string.IsNullOrEmpty(needRole))
        //        {
        //            var needRoleArray = StringHelper.StringSplit<long>(needRole);
        //            var userRoleArray = StringHelper.StringSplit<long>(MembershipManager.AdminSN.Role);
        //            if (needRoleArray.Any(e => userRoleArray.Contains(e)))
        //                return true;
        //        }
        //    }
        //    return false;
        //}
        //public bool HasRole(int needRole)
        //{
        //    return HasRole(needRole.ToString());
        //}
        ///// <summary>
        ///// 判断是否登录
        ///// </summary>
        ///// <returns></returns>
        //public bool IsLogin()
        //{
        //    bool boolRtn;
        //    boolRtn = false;
        //    if (MembershipManager.AdminSN == null || MembershipManager.AdminSN.AdminId.Equals(0))
        //    {
        //        MembershipManager.AdminSN = this.GetMembership();
        //        if (MembershipManager.AdminSN != null && !MembershipManager.AdminSN.AdminId.Equals(0))
        //        {
        //            boolRtn = true;
        //        }
        //        else
        //        {
        //            CookieAbandon();
        //        }
        //    }
        //    else
        //    {
        //        boolRtn = true;
        //    }
        //    return boolRtn;
        //}

        ///// <summary>
        ///// 获取当前用户的身份
        ///// </summary>
        ///// <returns></returns>
        //public AdminSessionItem GetMembership()
        //{
        //    AdminSessionItem oasItem = MembershipManager.AdminSN;
        //    HttpCookie ohcCookie = HttpContext.Current.Request.Cookies[GlobalConfig.AdminCookie];
        //    CookieCredential ocCredential = null;
        //    if (oasItem == null || oasItem.AdminId.Equals(0))
        //    {
        //        if (ohcCookie != null)
        //        {
        //            ocCredential = GetCookieCredential(ohcCookie, HttpContext.Current.Request.UserAgent);
        //        }
        //        if (oasItem == null || ocCredential == null || oasItem.AdminId != ocCredential.UserId)
        //        {
        //            oasItem = GetMembership(ocCredential);
        //            if (oasItem == null)
        //                oasItem = new AdminSessionItem();
        //        }
        //    }
        //    return oasItem;
        //}
        ///// <summary>
        ///// 根据Cookie凭证验证用户
        ///// </summary>
        ///// <param name="credential"></param>
        ///// <returns></returns>
        //public AdminSessionItem GetMembership(CookieCredential credential)
        //{
        //    AdminSessionItem oasItem = null;
        //    if (credential == null)
        //        return null;
        //    //var response = AdminService.CheckAdminLogin(credential.UserName, credential.Password);
        //    //if (response.Success && response.Result != null)
        //    //{
        //    //    oasItem = new AdminSessionItem();
        //    //    oasItem.AdminId = response.Result.id;
        //    //    oasItem.LoginName = response.Result.Login_Name;
        //    //    oasItem.Role = response.Result.Authority;
        //    //}
        //    return oasItem;
        //}
        ///// <summary>
        ///// 获取Cookie凭证
        ///// </summary>
        ///// <param name="ohcCookie"></param>
        ///// <param name="userAgent"></param>
        ///// <returns></returns>
        //public CookieCredential GetCookieCredential(HttpCookie ohcCookie, string userAgent)
        //{
        //    if (ohcCookie == null)
        //        return null;
        //    CookieCredential credential = new CookieCredential();
        //    try
        //    {
        //        credential.UserName = HttpUtility.UrlDecode(ohcCookie.Values["loginname"].ToString());
        //        credential.Password = EncryptHelper.MD5Decrypt(HttpUtility.UrlDecode(ohcCookie.Values["password"].ToString()), GlobalConfig.CookieEncryptKey);
        //        credential.UserId = int.Parse(ohcCookie.Values["adminid"].ToString());
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //    if (string.IsNullOrEmpty(credential.Password) || string.IsNullOrEmpty(credential.UserName) || credential.UserId.Equals(0))
        //    {
        //        return null;
        //    }
        //    return credential;
        //}
        #endregion
    }



    #region DTO
    public class CookieCredential
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int ParentId { get; set; }
    }
    public class AdminSessionItem
    {
        public int AdminId { get; set; }
        public string LoginName { get; set; }
        public string Role { get; set; }
        public string RoleName { get; set; }

    }

    #endregion


}
