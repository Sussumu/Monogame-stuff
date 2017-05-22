using Engine.Library.Components;
using System.Collections.Generic;

namespace Engine.Library.GameObjects
{
    public interface IGameObject
    {
        string Name { get; set; }
        List<Component> Components { get; set; }
        List<Mask> Masks { get; set; }
    }
}
