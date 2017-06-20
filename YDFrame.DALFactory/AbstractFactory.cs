using System.Reflection;
using YDFrame.Common;
using YDFrame.IDAL;

namespace YDFrame.DALFactory
{
    /************************************************************************************
         * Copyright (c) 2017  All Rights Reserved.
         * CLR版本： 4.0.30319.42000
         * 机器名称：DESKTOP-C7IEETR
         * 公司名称：南京马普科技有限公司
         * 文件名：  AbstractFactory
         * 版本号：  V1.0.0.0
         * 唯一标识：ae0cd148-73b1-4ba6-ab52-1679f417fc99
         * 当前的用户域：DESKTOP-C7IEETR
         * 创建人：  hexd 贺晓冬
         * 电子邮箱：675556820@qq.com
         * 创建时间：2017/6/14 14:34:00
         * 描述    :
         * =====================================================================
        *************************************************************************************/
    public partial class AbstractFactory
    {
        //private static readonly string DalAssembly = ConfigUtil.GetAppSettings("DalAssembly");
        //private static readonly string NameSpace = ConfigUtil.GetAppSettings("NameSpace");
        //public static ISys_MenuRepository CreateSys_MenuRepository()
        //{
        //    string fullClassName = NameSpace + ".Sys_MenuRepository";
        //    return CreateInstance(fullClassName, DalAssembly) as ISys_MenuRepository;
        //}
        public static object CreateInstance(string className, string assemblyName)
        {
            var assembly = Assembly.Load(assemblyName);
            return assembly.CreateInstance(className);
        }
    }
}
