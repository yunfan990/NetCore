using BT.Core.Repository.DbModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BT.Core
{
    public class HouTaiDbContext : DbContext
    {
        /// <summary>
        /// 上下文对象
        /// </summary>
        /// <param name="options"></param>
        public HouTaiDbContext(DbContextOptions<HouTaiDbContext> options) : base(options) { }

        /// <summary>
        /// 管理员表
        /// </summary>
        public DbSet<Account> Account { get; set; }

        public DbSet<Powers> Powers { get; set; }

        public DbSet<Roles> Roles { get; set; }

        public DbSet<AccountRoles> AccountRoles { get; set; }
    }
}
