using CommonReferences;
using LegendofZelda.Interfaces;
using LegendofZelda.Items;
using LegendofZelda.SpriteFactories;
using Microsoft.Xna.Framework;
using Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;


namespace LegendofZelda
{
    public class RoomLoader
    {
        public RoomLoader()
        {
           
        }
        public Room ParseXML(XDocument xml)
        {
            List<ISprite> sprites = new();

            //parse background
            string backgroundString = xml.Root.Descendants("Item").First().Element("ObjectName").Value;
            var backgroundSprite = BackgroundSpriteFactory.Instance.CreateBackground(backgroundString);

            List<string> spriteStrings = new List<string>(new string[] { "Block", "Enemy", "Item" });

            //for each sprite type to create (block, enemy, or item)
            foreach (var spriteString in spriteStrings)
            {
                //spritesToCreate is a list of XElements
                var spritesToCreate = from c in xml.Root.Descendants("Item")
                                      where c.Element("ObjectType").Value == spriteString
                                      select c;

                foreach (var spriteToCreate in spritesToCreate)
                {

                    string[] locationString = spriteToCreate.Element("Location").Value.Split(" ");
                    Vector2 location = new((float)Convert.ToDouble(locationString[0]), (float)Convert.ToDouble(locationString[1]));
                    if (spriteString == "Block")
                    {
                        sprites.Add(BlockSpriteFactory.Instance.CreateBlock(location, spriteToCreate.Element("ObjectName").Value));
                    }
                    else if(spriteString == "Enemy")
                    {
                        sprites.Add(EnemyAndNPCSpriteFactory.Instance.CreateEnemyOrNPC(location, spriteToCreate.Element("ObjectName").Value));
                    }
                    else if (spriteString == "Item")
                    {
                        sprites.Add(ItemSpriteFactory.Instance.CreateItem(location, spriteToCreate.Element("ObjectName").Value));
                    }
                }
            }

            if (sprites.OfType<OldManBoss>().Any())
            {
                return new Room(sprites, BackgroundSpriteFactory.Instance.CreateBackground("Background"+(Common.Instance.rushRoomsIndex+ Common.Instance.numOfRushRooms).ToString()), true);
            }else if (sprites.OfType<MasterSword>().Any())
            {
                return new Room(sprites, BackgroundSpriteFactory.Instance.CreateBackground("Background" + (Common.Instance.rushRoomsIndex + Common.Instance.numOfRushRooms+1).ToString()), false);
            }
            else
            {
                return new Room(sprites, backgroundSprite, false);
            }
               
        }

    }

}