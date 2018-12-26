using GeoAPI.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObjectProcessTool
{
    /// <summary>
    /// 工具接口
    /// </summary>
    public interface ITool
    {
        /// <summary>
        /// 工具名称
        /// </summary>
        string Name { get; }
        /// <summary>
        /// 光标样式
        /// </summary>
        Cursor Cursor { get; }
        /// <summary>
        /// 激活工具
        /// </summary>
        void Active();
        /// <summary>
        /// 卸载工具
        /// </summary>
        void UnActive();
        /// <summary>
        /// 地图鼠标按下
        /// </summary>
        /// <param name="worldPos">世界坐标</param>
        /// <param name="imagePos"></param>
        void MouseDown(Coordinate worldPos, MouseEventArgs imagePos);
        /// <summary>
        /// 地图鼠标移动
        /// </summary>
        /// <param name="worldPos">世界坐标</param>
        /// <param name="imagePos"></param>
        void MouseMove(Coordinate worldPos, MouseEventArgs imagePos);
        /// <summary>
        /// 地图鼠标抬起
        /// </summary>
        /// <param name="worldPos">世界坐标</param>
        /// <param name="imagePos"></param>
        void MouseUp(Coordinate worldPos, MouseEventArgs imagePos);
        /// <summary>
        /// 地图鼠标双击
        /// </summary>
        /// <param name="worldPos">世界坐标</param>
        /// <param name="imagePos"></param>
        void MouseDoubleClick(Coordinate worldPos, MouseEventArgs imagePos);
    }
}
