﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace YDFrame.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class YDFrameEntities : DbContext
    {
        public YDFrameEntities()
            : base("name=YDFrameEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Sys_Menu> Sys_Menu { get; set; }
        public virtual DbSet<Sys_Role> Sys_Role { get; set; }
        public virtual DbSet<Sys_RoleMenu> Sys_RoleMenu { get; set; }
        public virtual DbSet<Sys_User> Sys_User { get; set; }
        public virtual DbSet<Sys_UserRole> Sys_UserRole { get; set; }
        public virtual DbSet<YD_Article> YD_Article { get; set; }
        public virtual DbSet<WX_Account> WX_Account { get; set; }
        public virtual DbSet<WX_Type> WX_Type { get; set; }
        public virtual DbSet<Sys_Error> Sys_Error { get; set; }
        public virtual DbSet<Sys_Log> Sys_Log { get; set; }
        public virtual DbSet<Sys_Icon> Sys_Icon { get; set; }
    }
}
