using ObjectProcessTool.MapControl;
using ObjectProcessTool.Model;
using ObjectProcessTool.Util;
using SharpMap;
using SharpMap.Rendering.Decoration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectProcessTool.Command
{
    class DeleteSobjectCommand : ICommand
    {
        public string Name => "DeleteSobject";

        public void Execute(object sender, EventArgs e)
        {
            Map map = GlobalContainer.GetInstance<Map>("Map");
            ObjectMapBox mapBox = GlobalContainer.GetInstance<ObjectMapBox>("MapBox");

            foreach (IMapDecoration decoration in map.Decorations)
            {
                if (decoration is Entity)
                {
                    Entity entity = decoration as Entity;

                    if (entity.SObject != null)
                    {
                        entity.Graph.RemvoeEntity(entity);
                        entity.SObject.Layer.SObjects.Remove(entity.SObject);
                    }
                }
            }

            mapBox.Refresh();
        }
    }
}
