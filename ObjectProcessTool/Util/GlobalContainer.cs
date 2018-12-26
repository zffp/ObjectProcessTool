using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectProcessTool.Util
{

    /// <summary>
    /// 注册对象事件委托
    /// </summary>
    /// <param name="name"></param>
    /// <param name="type"></param>
    public delegate void RegisterDataEvent(string name, object type);

    /// <summary>
    /// 移除对象事件委托
    /// </summary>
    /// <param name="name"></param>
    public delegate void RemoveDataEvent(string name);

    /// <summary>
    /// 全局对象容器
    /// </summary>
    public class GlobalContainer:Singleton<GlobalContainer>
    {      

        /// <summary>
        /// 数据注册事件
        /// </summary>
        public event RegisterDataEvent RegisterData;

        /// <summary>
        /// 数据移除事件
        /// </summary>
        public event RemoveDataEvent RemoveData;

        private Dictionary<string, object> oblist;
        public GlobalContainer()
        {
            oblist = new Dictionary<string, object>();
        }
        /// <summary>
        /// 注册数据对象
        /// </summary>
        /// <param name="name">对象名称</param>
        /// <param name="type">对象引用</param>
        /// <returns></returns>
        public static bool Register(string name, object type)
        {
            try
            {
                if (Instance.oblist.ContainsKey(name))
                    Instance.oblist[name] = type;
                else
                    Instance.oblist.Add(name, type);

                if (Instance.RegisterData != null)
                    Instance.RegisterData(name, type);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
        /// <summary>
        /// 根据名称移除注册对象
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool Remove(string name)
        {
            if (Instance.RemoveData != null)
                Instance.RemoveData(name);

            return Instance.oblist.Remove(name);
        }
        /// <summary>
        /// 根据名称获取对象
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public object GetInstance(string name)
        {
            if (oblist.ContainsKey(name))
                return oblist[name];
            return null;
        }
        /// <summary>
        /// 根据名称获取泛型对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        public static T GetInstance<T>(string name) where T : class
        {
            return Instance.GetInstance(name) as T;
        }

    }
}
