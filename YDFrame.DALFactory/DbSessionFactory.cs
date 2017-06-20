using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using YDFrame.IDAL;

namespace YDFrame.DALFactory
{
    /************************************************************************************
         * Copyright (c) 2017  All Rights Reserved.
         * CLR版本： 4.0.30319.42000
         * 机器名称：DESKTOP-C7IEETR
         * 公司名称：南京马普科技有限公司
         * 文件名：  DbSessionFactory
         * 版本号：  V1.0.0.0
         * 唯一标识：37821fe0-4ca1-4f17-bb8a-4a94c73ab835
         * 当前的用户域：DESKTOP-C7IEETR
         * 创建人：  hexd 贺晓冬
         * 电子邮箱：675556820@qq.com
         * 创建时间：2017/6/14 14:56:50
         * 描述    :
         * =====================================================================
        *************************************************************************************/
    public static class DbSessionFactory
    {
        public static IDbSession CreateDbSession()
        {
            IDbSession DbSession = (IDbSession)CallContext.GetData("dbSession");
            if (DbSession == null)
            {
                DbSession = new DbSession();
                CallContext.SetData("dbSession", DbSession);
            }
            return DbSession;
        }
    }
}
