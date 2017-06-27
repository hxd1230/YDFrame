using NLog;
using System;
using System.Collections.Generic;
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
         * 文件名：  NogUtil
         * 版本号：  V1.0.0.0
         * 唯一标识：a7e6fc92-5bc3-4f0a-a17f-9b3976b0f5b7
         * 当前的用户域：DESKTOP-C7IEETR
         * 创建人：  hexd 贺晓冬
         * 电子邮箱：675556820@qq.com
         * 创建时间：2017/6/27 13:58:36
         * 描述    :
         * =====================================================================
        *************************************************************************************/
    public static class NLogUtil
    {
        private static ILogger _logger = LogManager.GetCurrentClassLogger();

        public static void Debug(string msg)
        {
            _logger.Debug(msg);
        }

        public static void Error(string msg)
        {
            _logger.Error(msg);
        }

        public static void Fatal(string msg)
        {
            _logger.Fatal(msg);
        }

        public static void Info(string msg)
        {
            _logger.Info(msg);
        }

        public static void Trace(string msg)
        {
            _logger.Trace(msg);
        }
    }
}
