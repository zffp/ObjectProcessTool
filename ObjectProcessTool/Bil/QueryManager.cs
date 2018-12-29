using ObjectProcessTool.MapControl;
using ObjectProcessTool.Model;
using ObjectProcessTool.UI;
using ObjectProcessTool.Util;
using SharpMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectProcessTool.Bil
{
    /// <summary>
    /// 查询管理
    /// </summary>
    class QueryManager : Singleton<QueryManager>
    {
        public void SetSelectEntity(Entity entity)
        {
            Map map = GlobalContainer.GetInstance<Map>("Map");
            ObjectMapBox mapBox = GlobalContainer.GetInstance<ObjectMapBox>("MapBox");


            PropertyUserControl propertyUserControl = GlobalContainer.GetInstance<PropertyUserControl>("PropertyUserControl");
            propertyUserControl.SetFeatureData(entity);
            map.Decorations.Clear();
            if (entity != null)
            {
                map.Decorations.Add(entity);
            }
            mapBox.Refresh();
        }
    }
}
