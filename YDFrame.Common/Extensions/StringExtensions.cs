using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YDFrame.Common.Extensions
{
    /************************************************************************************
         * Copyright (c) 2017  All Rights Reserved.
         * CLR版本： 4.0.30319.42000
         * 机器名称：DESKTOP-C7IEETR
         * 公司名称：南京马普科技有限公司
         * 文件名：  StringExtensions
         * 版本号：  V1.0.0.0
         * 唯一标识：dbb3cd4e-19ba-4b74-88ea-66e171d366e5
         * 当前的用户域：DESKTOP-C7IEETR
         * 创建人：  hexd 贺晓冬
         * 电子邮箱：675556820@qq.com
         * 创建时间：2017/6/12 17:15:06
         * 描述    :
         * =====================================================================
        *************************************************************************************/
    public static class StringExtensions
    {
        public static int ToInt32(this string str)
        {
            return Convert.ToInt32(str);
        }
        public static bool ToBoolean(this string str)
        {
            return Convert.ToBoolean(str);
        }
    }
}
