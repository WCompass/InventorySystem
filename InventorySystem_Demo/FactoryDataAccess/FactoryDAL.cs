using System;

namespace FactoryDataAccess
{
    public class DataAccess<T> where T : class
    {
        //获取配置路径
        private static readonly string path = System.Configuration.ConfigurationManager.AppSettings["DAL"];
        private DataAccess() { }

        /// <summary>
        /// 创建实例
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static T CreateDAL(string type)
        {
            string className = path + "." + type;
            try
            {
                return (T)System.Reflection.Assembly.Load(path).CreateInstance(className);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
    }
}
