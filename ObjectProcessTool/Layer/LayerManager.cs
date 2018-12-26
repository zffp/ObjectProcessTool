using NetTopologySuite.Geometries;
using ObjectProcessTool.MapControl;
using ObjectProcessTool.UI;
using ObjectProcessTool.Util;
using SharpMap;
using SharpMap.Layers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectProcessTool.Layer
{
    /// <summary>
    /// 图层管理
    /// </summary>
    class LayerManager : Singleton<LayerManager>
    {
        Map map;
        ObjectMapBox objectMapBox;
        public LayerManager()
        {
            GeometryFactory geometryFactory = new GeometryFactory();

            map = GlobalContainer.GetInstance<Map>("Map");
            objectMapBox = GlobalContainer.GetInstance<ObjectMapBox>("MapBox");

        }

        public void AddLayer(ILayer layer)
        {
            map.Layers.Add(layer);
            map.ZoomToExtents();
            objectMapBox.Refresh();


            LayerCtrlUserControl layerCtrlUserControl = GlobalContainer.GetInstance<LayerCtrlUserControl>("LayerCtrlUserControl");
            layerCtrlUserControl.AddLayer(layer);
        }
        public void RemoveLayer(ILayer layer)
        {
            map.Layers.Remove(layer);
            objectMapBox.Refresh();

            LayerCtrlUserControl layerCtrlUserControl = GlobalContainer.GetInstance<LayerCtrlUserControl>("LayerCtrlUserControl");
            layerCtrlUserControl.RemoveLayer(layer);
        }
        public void SetLayerVisible(string layerName, bool visible)
        {
            ILayer layer = map.Layers.FirstOrDefault(r => r.LayerName == layerName);
            if (layer != null)
            {
                layer.Enabled = visible;

                objectMapBox.Refresh();
            }
        }
    }
}
