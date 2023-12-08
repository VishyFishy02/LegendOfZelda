using Microsoft.Xna.Framework;
using System.Collections.Generic;
using LegendofZelda;
using LegendofZelda;
using LegendofZelda.Interfaces;
using System.Diagnostics;
using Sprites;

namespace Collision
{
    public class CollisionDetector
	{
        private Game1 currGame;
		private List<ISprite> objects;
		private List<ISprite> alreadyChecked;
		private CollisionDelegator handler;
		private Room currRoom;
		
		public CollisionDetector(Room room, Game1 game)
		{
			this.currGame = game;
			// initialize room instance and also get the current collideable objects from it
			this.currRoom = room;
			this.objects = room.ReturnObjects();
			this.alreadyChecked = new List<ISprite>();
			this.handler = new CollisionDelegator(room, game);
		}

		/*
		 *  Update method will constantly be checking all objects for a collision
		 */
		public void Update()
		{	
			this.currRoom = this.currGame.currentRoom;
			this.handler = new CollisionDelegator(currRoom, this.currGame);
			// refresh objects array with the current room's objects and add link in there
			this.objects = currRoom.ReturnObjects();
            
            ISprite currLinkSprite = Link.Instance.currentLinkSprite;
            this.objects.Add(currLinkSprite);
			this.alreadyChecked.Clear();

			foreach (ISprite obj in this.objects)
			{
				foreach (ISprite otherObj in this.objects)
				{
					checkForCollision(obj, otherObj);
				}
				// now that we've checked all the possible collision interactions with this object, we don't need to again for now
				this.alreadyChecked.Add(obj);
			}
            this.objects.Remove(currLinkSprite);
        }
	
		private void checkForCollision(ISprite obj, ISprite otherObj)
		{
			if (obj != otherObj && !alreadyChecked.Contains(otherObj))
			{   
				// only check for collision if object has not already been compared to all other objects
				if (detectCollision(obj, otherObj))
				{
                    // pass some stuff and let the handler handle it from here
                    this.handler.handleCollision(obj, otherObj);
				}
			}
        }
        private bool detectCollision(ISprite obj, ISprite otherObj)
        {
            Rectangle objectRec = obj.DestinationRectangle;
			Rectangle otherRec = otherObj.DestinationRectangle;
            return objectRec.Intersects(otherRec);
        }
    }
}
