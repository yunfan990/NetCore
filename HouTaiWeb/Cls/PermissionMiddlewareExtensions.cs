using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BT.Model.ViewModel.PermissionMiddleware;

namespace HouTaiWeb
{
    public static class PermissionMiddlewareExtensions
    {
        public static IApplicationBuilder UserPermission(this IApplicationBuilder builder, PermissionMiddlewareOptionViewModel options)
        {
            return builder.UseMiddleware<PermissionMiddleware>(options);
        }
    }
}
