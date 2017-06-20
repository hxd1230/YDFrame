/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2008                    */
/* Created on:     2017/5/27 11:34:36                           */
/*==============================================================*/
IF not EXISTS(SELECT  *
            FROM    sys.databases
            WHERE   name = 'YDFrame')
CREATE DATABASE YDFrame ON PRIMARY 
( NAME = N'bbsDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\YDFrame.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
    LOG ON 
( NAME = N'bbsDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\YDFrame_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
    COLLATE Chinese_PRC_CI_AS
GO

use YDFrame;

if exists (select 1
            from  sysobjects
           where  id = object_id('Sys_LoginLog')
            and   type = 'U')
   drop table Sys_LoginLog
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Sys_Menu')
            and   type = 'U')
   drop table Sys_Menu
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Sys_Role')
            and   type = 'U')
   drop table Sys_Role
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Sys_RoleMenu')
            and   type = 'U')
   drop table Sys_RoleMenu
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Sys_User')
            and   type = 'U')
   drop table Sys_User
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Sys_UserRole')
            and   type = 'U')
   drop table Sys_UserRole
go

/*==============================================================*/
/* Table: Sys_LoginLog                                          */
/*==============================================================*/
create table Sys_LoginLog (
   Id                   int                  identity,
   UserId               int                  null,
   LoginTime            datetime             null default getdate(),
   LoginIp              varchar(16)          null,
   LoginOutTime         datetime             null
)
go

/*==============================================================*/
/* Table: Sys_Menu                                              */
/*==============================================================*/
create table Sys_Menu (
   Id                   int                  identity,
   Name                 varchar(20)          null,
   ParentId             int                  null,
   Url                  varchar(50)          null,
   Icon                 varchar(20)          null,
   IsHide               bit                  null default 0,
   Description          varchar(20)          null,
   constraint PK_SYS_MENU primary key (Id)
)
go

/*==============================================================*/
/* Table: Sys_Role                                              */
/*==============================================================*/
create table Sys_Role (
   Id                   int                  identity,
   Name                 varchar(20)          null,
   State                int                  null default 0,
   Description          varchar(20)          null,
   constraint PK_SYS_ROLE primary key (Id)
)
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Sys_Role')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Sys_Role', 'column', 'Id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '自增编号',
   'user', @CurrentUser, 'table', 'Sys_Role', 'column', 'Id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Sys_Role')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Name')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Sys_Role', 'column', 'Name'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '角色名',
   'user', @CurrentUser, 'table', 'Sys_Role', 'column', 'Name'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Sys_Role')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'State')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Sys_Role', 'column', 'State'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '0默认，1禁用',
   'user', @CurrentUser, 'table', 'Sys_Role', 'column', 'State'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Sys_Role')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Description')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Sys_Role', 'column', 'Description'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '描述',
   'user', @CurrentUser, 'table', 'Sys_Role', 'column', 'Description'
go

/*==============================================================*/
/* Table: Sys_RoleMenu                                          */
/*==============================================================*/
create table Sys_RoleMenu (
   Id                   int                  identity,
   RoleId               int                  null,
   MenuId               int                  null,
   constraint PK_SYS_ROLEMENU primary key (Id)
)
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Sys_RoleMenu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Sys_RoleMenu', 'column', 'Id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '自增编号',
   'user', @CurrentUser, 'table', 'Sys_RoleMenu', 'column', 'Id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Sys_RoleMenu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'RoleId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Sys_RoleMenu', 'column', 'RoleId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '角色Id',
   'user', @CurrentUser, 'table', 'Sys_RoleMenu', 'column', 'RoleId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Sys_RoleMenu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'MenuId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Sys_RoleMenu', 'column', 'MenuId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '菜单编号',
   'user', @CurrentUser, 'table', 'Sys_RoleMenu', 'column', 'MenuId'
go

/*==============================================================*/
/* Table: Sys_User                                              */
/*==============================================================*/
create table Sys_User (
   Id                   int                  identity,
   UserName             varchar(20)          null,
   NickName             varchar(20)          null,
   Description          varchar(20)          null,
   IsLock               bit                  null default 0,
   CreateTime           datetime             null default getdate(),
   DelFlag              bit                  null default 0,
   PassWord             varchar(32)          null,
   constraint PK_SYS_USER primary key (Id)
)
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Sys_User')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Sys_User', 'column', 'Id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '自增编号',
   'user', @CurrentUser, 'table', 'Sys_User', 'column', 'Id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Sys_User')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UserName')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Sys_User', 'column', 'UserName'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '用户名',
   'user', @CurrentUser, 'table', 'Sys_User', 'column', 'UserName'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Sys_User')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'NickName')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Sys_User', 'column', 'NickName'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '用户昵称',
   'user', @CurrentUser, 'table', 'Sys_User', 'column', 'NickName'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Sys_User')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Description')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Sys_User', 'column', 'Description'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '描述',
   'user', @CurrentUser, 'table', 'Sys_User', 'column', 'Description'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Sys_User')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IsLock')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Sys_User', 'column', 'IsLock'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '0未锁定，1锁定',
   'user', @CurrentUser, 'table', 'Sys_User', 'column', 'IsLock'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Sys_User')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Sys_User', 'column', 'CreateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建时间',
   'user', @CurrentUser, 'table', 'Sys_User', 'column', 'CreateTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Sys_User')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DelFlag')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Sys_User', 'column', 'DelFlag'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '0未删除，1删除',
   'user', @CurrentUser, 'table', 'Sys_User', 'column', 'DelFlag'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Sys_User')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'PassWord')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Sys_User', 'column', 'PassWord'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '用户密码',
   'user', @CurrentUser, 'table', 'Sys_User', 'column', 'PassWord'
go

/*==============================================================*/
/* Table: Sys_UserRole                                          */
/*==============================================================*/
create table Sys_UserRole (
   Id                   int                  identity,
   UserId               int                  null,
   RoleId               int                  null,
   constraint PK_SYS_USERROLE primary key (Id)
)
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Sys_UserRole')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Sys_UserRole', 'column', 'Id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '自增编号',
   'user', @CurrentUser, 'table', 'Sys_UserRole', 'column', 'Id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Sys_UserRole')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UserId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Sys_UserRole', 'column', 'UserId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '用户编号',
   'user', @CurrentUser, 'table', 'Sys_UserRole', 'column', 'UserId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Sys_UserRole')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'RoleId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Sys_UserRole', 'column', 'RoleId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '角色编号',
   'user', @CurrentUser, 'table', 'Sys_UserRole', 'column', 'RoleId'
go

/*==============================================================*/
/* Table: YD_Article                                            */
/*==============================================================*/
create table YD_Article (
   Id                   int                  identity,
   Title                nvarchar(255)        null,
   Content              text                 null,
   CreateTime           datetime             null default getdate(),
   UserId               int                  null,
   constraint PK_YD_ARTICLE primary key (Id)
)
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('YD_Article')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Title')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'YD_Article', 'column', 'Title'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '文章标题',
   'user', @CurrentUser, 'table', 'YD_Article', 'column', 'Title'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('YD_Article')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Content')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'YD_Article', 'column', 'Content'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '文章内容',
   'user', @CurrentUser, 'table', 'YD_Article', 'column', 'Content'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('YD_Article')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'YD_Article', 'column', 'CreateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建时间',
   'user', @CurrentUser, 'table', 'YD_Article', 'column', 'CreateTime'
go




---------------------------公众号---------------------------
/*==============================================================*/
/* Table: WX_Account                                            */
/*==============================================================*/
create table WX_Account (
   Id                   int                  identity,
   OriginalId           varchar(255)         null,
   AppId                varchar(255)         null,
   AppName              varchar(255)         null,
   AppCode              varchar(255)         null,
   AppPic               varchar(255)         null,
   AppEncodingAESKey    varchar(255)         null,
   AppUrl               varchar(255)         null,
   AppToken             varchar(255)         null,
   AppSecret            varchar(255)         null,
   TypeId               int                  null,
   AppAccessToken       varchar(255)         null,
   Enable               bit                  null,
   IsDefault            bit                  null,
   CreateTime           datetime             null,
   ModifyTime           datetime             null,
   constraint PK_WX_ACCOUNT primary key (Id)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('WX_Account') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'WX_Account' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '公众号管理', 
   'user', @CurrentUser, 'table', 'WX_Account'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('WX_Account')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'OriginalId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'WX_Account', 'column', 'OriginalId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '原始Id',
   'user', @CurrentUser, 'table', 'WX_Account', 'column', 'OriginalId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('WX_Account')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'AppName')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'WX_Account', 'column', 'AppName'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '公众号名称',
   'user', @CurrentUser, 'table', 'WX_Account', 'column', 'AppName'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('WX_Account')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'AppCode')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'WX_Account', 'column', 'AppCode'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '公众号账号',
   'user', @CurrentUser, 'table', 'WX_Account', 'column', 'AppCode'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('WX_Account')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'AppPic')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'WX_Account', 'column', 'AppPic'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '公众号头像',
   'user', @CurrentUser, 'table', 'WX_Account', 'column', 'AppPic'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('WX_Account')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'AppUrl')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'WX_Account', 'column', 'AppUrl'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '服务器地址',
   'user', @CurrentUser, 'table', 'WX_Account', 'column', 'AppUrl'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('WX_Account')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'TypeId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'WX_Account', 'column', 'TypeId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '说明',
   'user', @CurrentUser, 'table', 'WX_Account', 'column', 'TypeId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('WX_Account')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'AppAccessToken')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'WX_Account', 'column', 'AppAccessToken'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '访问token
   ',
   'user', @CurrentUser, 'table', 'WX_Account', 'column', 'AppAccessToken'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('WX_Account')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Enable')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'WX_Account', 'column', 'Enable'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '是否启用，1,启用，2未启用',
   'user', @CurrentUser, 'table', 'WX_Account', 'column', 'Enable'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('WX_Account')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IsDefault')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'WX_Account', 'column', 'IsDefault'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '是否是默认公众号',
   'user', @CurrentUser, 'table', 'WX_Account', 'column', 'IsDefault'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('WX_Account')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ModifyTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'WX_Account', 'column', 'ModifyTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '修改时间',
   'user', @CurrentUser, 'table', 'WX_Account', 'column', 'ModifyTime'
go

/*==============================================================*/
/* Table: WX_Type                                               */
/*==============================================================*/
create table WX_Type (
   Id                   int                  identity,
   Name                 varchar(6)           null,
   constraint PK_WX_TYPE primary key (Id)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('WX_Type') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'WX_Type' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '公众号类型', 
   'user', @CurrentUser, 'table', 'WX_Type'
go

---------------------------公众号---------------------------




-------------------华丽分割线-------------------
--添加用户
insert into sys_user(username,nickname,password)values('admin','晓冬冬','21232f297a57a5a743894a0e4a801fc3');
--添加角色
insert into sys_role(name,description)values(N'超级管理员','超级管理员');
--添加用户对应角色
insert into sys_userrole(userid,roleid)values(1,1);
--添加菜单
insert into sys_menu(name,parentid)values(N'系统基础管理',0);
--添加子菜单
insert into sys_menu(name,parentid,url)values(N'菜单管理',1,'/Admin/SysMenu/MenuList');
insert into sys_menu(name,parentid,url)values(N'角色管理',1,'/Admin/SysRole/RoleList');
insert into sys_menu(name,parentid,url)values(N'用户管理',1,'/Admin/SysUser/UserList');
insert into sys_menu(name,parentid,url)values(N'文章管理',1,'/Admin/YD_Article/Articles');
--添加角色对应菜单
insert into sys_rolemenu values(1,1);
insert into sys_rolemenu values(1,2);
insert into sys_rolemenu values(1,3);
insert into sys_rolemenu values(1,4);
insert into sys_rolemenu values(1,5);
-------------------华丽分割线-------------------
--用户加载菜单
select d.id,d.name,d.parentId,d.url from sys_user a,sys_userrole b,sys_rolemenu c,sys_menu d where username = 'admin'
and a.id = b.userid
and b.roleid = c.roleid
and c.menuid = d.id
--删除用户
--drop table sys_user
--删除角色
--drop table sys_role
--删除用户对应角色
--drop table sys_userrole
--删除菜单
--drop table sys_menu
--删除角色对应菜单
--drop table sys_rolemenu

--用户所属角色
select a.*,c.Name RoleName from Sys_User a,Sys_UserRole b,Sys_Role c
where a.Id = b.UserId
and b.RoleId = c.Id

insert into wx_type values(N'服务号'),(N'订阅号')





select * from wx_type