using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YDFrame.Common
{
    /************************************************************************************
         * Copyright (c) 2017  All Rights Reserved.
         * CLR版本： 4.0.30319.42000
         * 机器名称：DESKTOP-C7IEETR
         * 公司名称：南京马普科技有限公司
         * 文件名：  ConfigUtil
         * 版本号：  V1.0.0.0
         * 唯一标识：0ecaa27d-fbcc-4b46-a815-2ed98c141e5b
         * 当前的用户域：DESKTOP-C7IEETR
         * 创建人：  hexd 贺晓冬
         * 电子邮箱：675556820@qq.com
         * 创建时间：2017/6/14 14:35:34
         * 描述    :
         * =====================================================================
        *************************************************************************************/
    public static class ConfigUtil
    {
        public static string GetAppSettings(string name)
        {
            return ConfigurationManager.AppSettings[name];
        }
    }
}
