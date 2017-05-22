using Engine.Library.GameObjects;
using Microsoft.Xna.Framework.Content;
using Engine.Library.Graphics;
using Engine.Library.Components;
using System.Collections.Generic;

namespace Orion.Nodes.Prefabs
{
	public class Person : IGameObject
	{
		public string Name { get; set; }
		public List<Component> Components { get; set; }
		public List<Mask> Masks { get; set; }
		
		public Person(ContentManager content)
		{
			Components = new List<Component>() { new SpriteComponent("Player/player") };
		}
	}
}
