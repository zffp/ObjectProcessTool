using GeoAPI.Geometries;
using ObjectProcessTool.MapControl;
using ObjectProcessTool.Util;
using SharpMap;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObjectProcessTool.Tool
{
    /// <summary>
    /// 工具管理
    /// </summary>
    public class ToolManage : Singleton<ToolManage>
    {

        List<ITool> ToolList = new List<ITool>();

        private ITool curTool;
        /// <summary>
        /// 当前工具的名称
        /// </summary>
        private string toolName;

        /// <summary>
        /// 当前工具
        /// </summary>
        public string CurTool
        {
            get
            {
                return toolName;
            }
            set
            {
                var tool = GetTool(value);

                if (tool == null || curTool == tool)
                    return;

                toolName = value;

                if (curTool != null)
                    curTool.UnActive();
                curTool = tool;
                curTool.Active();
                if (curTool != null)
                {
                    ObjectMapBox mapbox = GlobalContainer.GetInstance<ObjectMapBox>("MapBox");
                    mapbox.Cursor = curTool.Cursor;
                }
            }
        }

        public ToolManage()
        {

        }

        public void AddTool(ITool tool)
        {
            if (ToolList.Where(r => r.Name == tool.Name).Count() > 0)
                return;

            ToolList.Add(tool);
        }

        public ITool GetTool(string name)
        {
            return ToolList.FirstOrDefault(r => r.Name == name);
        }

        public void RemoveTool(string name)
        {
            ToolList.RemoveAll(r => r.Name == name);
        }

        public void MouseDown(Coordinate worldPos, MouseEventArgs imagePos)
        {
            if (curTool != null)
                curTool.MouseDown(worldPos, imagePos);
        }

        public void MouseMove(Coordinate worldPos, MouseEventArgs imagePos)
        {
            ObjectMapBox mapbox = GlobalContainer.GetInstance<ObjectMapBox>("MapBox");
            mapbox.Focus();
            if (curTool != null)
                curTool.MouseMove(worldPos, imagePos);
        }

        public void MouseUp(Coordinate worldPos, MouseEventArgs imagePos)
        {
            if (curTool != null)
                curTool.MouseUp(worldPos, imagePos);
        }

        public void MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (curTool != null)
            {
                Map map = GlobalContainer.GetInstance<Map>("Map");
                curTool.MouseDoubleClick(map.ImageToWorld(new Point(e.X, e.Y)), e);
            }
        }
    }
}
