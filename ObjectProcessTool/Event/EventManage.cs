using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectProcessTool.Event
{

    public class Event
    {
        /// <summary>
        /// 事件名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 回调方法
        /// </summary>
        public Delegate CallBack { get; set; }
        /// <summary>
        /// 注册对象
        /// </summary>
        public object Caller { get; set; }
    }

    public class EventManage
    {
        private static EventManage instance = null;
        public static EventManage Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EventManage();
                }
                return instance;
            }
        }

        public List<Event> eventList = new List<Event>();
        public EventManage()
        {

        }
        /// <summary>
        /// 注册事件
        /// </summary>
        /// <returns></returns>
        public void RegisterEvent(object caller, string eventName, Delegate callback)
        {
            eventList.Add(new Event() { Caller = caller, Name = eventName, CallBack = callback });
        }
        public void RegisterEvent(object caller, string[] eventNameList, Delegate callback)
        {
            foreach (var enventName in eventNameList)
                RegisterEvent(callback, enventName, callback);
        }
        /// <summary>
        /// 异常注册事件
        /// </summary>
        /// <param name="caller"></param>
        /// <param name="eventName"></param>
        /// <returns></returns>
        public bool RemoveEvent(object caller, string eventName)
        {
            return eventList.RemoveAll(r => r.Caller == caller && r.Name == eventName) > 0;
        }
        /// <summary>
        /// 发送事件
        /// </summary>
        public void FireEvent<T1>(string eventName, T1 data)
        {
            FireEvent(eventName, new object[] { data });
        }
        public void FireEvent<T1, T2>(string eventName, T1 data1, T2 data2)
        {
            FireEvent(eventName, new object[] { data1, data2 });
        }
        public void FireEvent<T1, T2, T3>(string eventName, T1 data1, T2 data2, T3 data3)
        {
            FireEvent(eventName, new object[] { data1, data2, data3 });
        }
        public void FireEvent<T1, T2, T3, T4>(string eventName, T1 data1, T2 data2, T3 data3, T4 data4)
        {
            FireEvent(eventName, new object[] { data1, data2, data3, data4 });
        }
        public void FireEvent<T1, T2, T3, T4, T5>(string eventName, T1 data1, T2 data2, T3 data3, T4 data4, T5 data5)
        {
            FireEvent(eventName, new object[] { data1, data2, data3, data4, data5 });
        }
        public void FireEvent<T1, T2, T3, T4, T5, T6>(string eventName, T1 data1, T2 data2, T3 data3, T4 data4, T5 data5, T6 data6)
        {
            FireEvent(eventName, new object[] { data1, data2, data3, data4, data5, data6 });
        }

        public void FireEvent(string eventName)
        {
            for (int i = 0; i < eventList.Count; i++)
            {
                if (eventList[i].Name == eventName)
                {
                    eventList[i].CallBack.DynamicInvoke();
                }
            }
        }
        public void FireEvent(string eventName, object[] par)
        {
            for (int i = 0; i < eventList.Count; i++)
            {
                if (eventList[i].Name == eventName)
                {
                    eventList[i].CallBack.DynamicInvoke(par);
                }
            }
        }
        public Event GetEvent(string eventName)
        {
            for (int i = 0; i < eventList.Count; i++)
            {
                if (eventList[i].Name == eventName)
                {
                    return eventList[i];
                }
            }
            return null;

        }
    }
}
