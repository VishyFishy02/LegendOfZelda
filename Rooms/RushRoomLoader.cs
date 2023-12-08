using LegendofZelda.Interfaces;
using LegendofZelda.Rooms;
using LegendofZelda.SpriteFactories;
using Microsoft.Xna.Framework;
using Sprites;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;


namespace LegendofZelda
{
    public class RushRoomLoader
    {
        Dictionary<int, Vector2> coordinates;
        public RushRoomLoader(RandomRoomGenerator rushRoomLoader)
        {
            this.coordinates = rushRoomLoader.locations;
        }
        public List<ISprite> ParseXML(XDocument xml)
        {
            List<ISprite> sprites = new();

            //spritesToCreate is a list of XElements
            var spritesToCreate = from c in xml.Root.Descendants("Item")
                                  where c.Element("ObjectType").Value == "Block"
                                  select c;

            foreach (var spriteToCreate in spritesToCreate)
            {
                string locationString = spriteToCreate.Element("Location").Value;
                int location = Int32.Parse(locationString);
                Vector2 vector = new();
                if (coordinates.ContainsKey(location))
                {
                    vector = coordinates[location];
                    coordinates.Remove(location);
                }
                sprites.Add(BlockSpriteFactory.Instance.CreateBlock(vector, spriteToCreate.Element("ObjectName").Value));
            }

            return sprites;

        }
    }
}
