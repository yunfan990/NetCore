using System;
using System.Collections.Generic;
using System.Text;

namespace BT.Model.ViewModel.PermissionMiddleware
{
    public class PermissionMiddlewareOptionViewModel
    {
        /// <summary>
        /// 登录action
        /// </summary>
        public string LoginAction { get; set; }

        public string NoPermissionAction { get; set; }

        public List<UserPermissionViewModel> UserPerssion { get; set; } = new List<UserPermissionViewModel>();
    }
}
