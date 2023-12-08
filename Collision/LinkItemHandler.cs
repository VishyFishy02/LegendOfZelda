using LegendofZelda;
using LegendofZelda;
using LegendofZelda.Interfaces;
using LegendofZelda.Items;
using LegendofZelda.SpriteFactories;

namespace Collision
{
    public static class LinkItemHandler
	{		
		static LinkItemHandler()
		{
		}
		public static void handleCollision(IItem item, Room room)
		{
			SoundFactory.Instance.CreateSoundEffect("ItemPickup").Play();
			Link.Instance.inventory.addItem(item);
            room.RemoveObject(item);
            switch (item)
			{
				case SmallRedHeart:
				case SmallBlueHeart:
                    Link.Instance.health += 1.0f;
					if(Link.Instance.health > Link.Instance.maxHealth)
					{
						Link.Instance.health = Link.Instance.maxHealth;
					}
					break;

                case BigHeart:
                    Link.Instance.health += 1.0f;
                    Link.Instance.maxHealth = 4;
                    if (Link.Instance.health > Link.Instance.maxHealth)
                    {
                        Link.Instance.health = Link.Instance.maxHealth;
                    }
					break;

				case Fairy:
                    Link.Instance.health = Link.Instance.maxHealth;
					break;

				case Triforce:
                    Link.Instance.health = Link.Instance.maxHealth;
					SoundFactory.Instance.CreateSoundEffect("Winning").Play();
					Link.Instance.game.gameStateController.gameState.WinGame();
					break;
				case MasterSword:
					Link.Instance.masterSwordEquipped = true;
					break;

				case Clock:
					Link.Instance.game.gameStateController.gameState.EnemiesPause();
					break;
                default:
					break;

            }
		}        
	}
}
