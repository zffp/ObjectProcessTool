using GeoAPI.Geometries;
using ObjectProcessTool.Event;
using ObjectProcessTool.MapControl;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObjectProcessTool.Tool
{
    public class PanTool : AbstractTool
    {
        public override string Name
        {
            get { return "PanTool"; }
        }
        public override Cursor Cursor
        {
            get
            {
                return Cursors.Hand;
            }
        }
        private Point _dragStartPoint;
        private Point _dragEndPoint;
        private Coordinate _dragStartCoord;
        ObjectMapBox mapbox;
        public PanTool(ObjectMapBox objectMapBox)
        {
            this.mapbox = objectMapBox;
            EventManage.Instance.RegisterEvent(this, EventNameList.START_DRAGMAP,
                new Action<Coordinate, MouseEventArgs, ObjectMapBox>((worldPos, imagePos, ombx) =>
                {
                    if (mapbox != ombx)
                        return;

                    _dragStartPoint = imagePos.Location;
                    _dragEndPoint = imagePos.Location;
                    _dragStartCoord = mapbox.Map.Center;


                }));

            EventManage.Instance.RegisterEvent(this, EventNameList.DRAGMAP,
                 new Action<Coordinate, MouseEventArgs, ObjectMapBox>((worldPos, imagePos, ombx) =>
                 {
                     if (mapbox != ombx)
                         return;

                     _dragEndPoint = imagePos.Location;
                     if (_dragStartCoord != null)
                     {
                         mapbox.Map.Center =
                             new Coordinate(_dragStartCoord.X - mapbox.Map.PixelSize * (_dragEndPoint.X - _dragStartPoint.X),
                                          _dragStartCoord.Y - mapbox.Map.PixelSize * (_dragStartPoint.Y - _dragEndPoint.Y));

                         mapbox.Invalidate();
                     }
                 }));

            EventManage.Instance.RegisterEvent(this, EventNameList.END_DARGMAP,
                new Action<Coordinate, MouseEventArgs, ObjectMapBox, bool>((worldPos, imagePos, ombx, isRefresh) =>
                {
                    if (mapbox != ombx)
                        return;

                    _dragStartCoord = null;
                    if (isRefresh)
                    {

                        mapbox.Refresh();
                    }
                }));
        }

        public override void MouseDown(Coordinate worldPos, MouseEventArgs imagePos)
        {
            EventManage.Instance.FireEvent(EventNameList.START_DRAGMAP, worldPos, imagePos, mapbox);
        }
        public override void MouseMove(Coordinate worldPos, MouseEventArgs imagePos)
        {
            EventManage.Instance.FireEvent(EventNameList.DRAGMAP, worldPos, imagePos, mapbox);
        }
        public override void MouseUp(Coordinate worldPos, MouseEventArgs imagePos)
        {
            EventManage.Instance.FireEvent(EventNameList.END_DARGMAP, worldPos, imagePos, mapbox, true);
        }

    }
}
