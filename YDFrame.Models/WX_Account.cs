
//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
public partial class WX_Account
{

    public int Id { get; set; }

    public string OriginalId { get; set; }

    public string AppId { get; set; }

    public string AppName { get; set; }

    public string AppCode { get; set; }

    public string AppPic { get; set; }

    public string AppEncodingAESKey { get; set; }

    public string AppUrl { get; set; }

    public string AppToken { get; set; }

    public string AppSecret { get; set; }

    public Nullable<int> TypeId { get; set; }

    public string AppAccessToken { get; set; }

    public Nullable<bool> Enable { get; set; }

    public Nullable<bool> IsDefault { get; set; }

    public Nullable<System.DateTime> CreateTime { get; set; }

    public Nullable<System.DateTime> ModifyTime { get; set; }

}

}