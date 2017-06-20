using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YDFrame.Models.Sys
{
    /************************************************************************************
         * Copyright (c) 2017  All Rights Reserved.
         * CLR版本： 4.0.30319.42000
         * 机器名称：DESKTOP-C7IEETR
         * 公司名称：南京马普科技有限公司
         * 文件名：  SysLogModel
         * 版本号：  V1.0.0.0
         * 唯一标识：dfb119ba-9cb1-4378-8ea7-ea2fad055d17
         * 当前的用户域：DESKTOP-C7IEETR
         * 创建人：  hexd 贺晓冬
         * 电子邮箱：675556820@qq.com
         * 创建时间：2017/5/26 9:17:22
         * 描述    :
         * =====================================================================
        *************************************************************************************/
    public class SysLogModel
    {


        [Display(Name = "ID")]
        public string Id { get; set; }

        [Display(Name = "操作人")]
        public string Operator { get; set; }

        [Display(Name = "信息")]
        public string Message { get; set; }

        [Display(Name = "结果")]
        public string Result { get; set; }

        [Display(Name = "类型")]
        public string Type { get; set; }

        [Display(Name = "模块")]
        public string Module { get; set; }

        [Display(Name = "创建时间")]
        public DateTime? CreateTime { get; set; }
    }
}
