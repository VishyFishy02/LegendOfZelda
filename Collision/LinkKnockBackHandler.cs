using Microsoft.Xna.Framework;
using States;
using Interfaces;
using Microsoft.Xna.Framework.Graphics;
using LegendofZelda.SpriteFactories;
using LegendofZelda.Interfaces;
using System.Collections.Generic;
using GameStates;
using System.Windows.Forms;

namespace LegendofZelda.Collision
{
    public static class LinkKnockBackHandler
    {
        // Vector2 currentPosition, bool isDamaged, int isDamagedCounter, ILinkState currentState, ISprite currentLinkSprite, string side 
        public static void TakeKnockBack()
        {
            // This can be refactored using a decorator pattern
            if (Link.Instance.isDamaged)
            {
                Link.Instance.isDamagedCounter++;

                // Take knockback for the first x frames
                if (Link.Instance.isDamagedCounter < 10)
                {
                    int knockbackDistance = 5;
                    switch (Link.Instance.side)
                    {
                        case "top":
                            Link.Instance.currentPosition.Y += knockbackDistance;
                            if (Link.Instance.currentPosition.Y < 238)
                            {
                                Link.Instance.currentPosition.Y = 300;
                                Link.Instance.isDamagedCounter = 10;
                            }
                            Link.Instance.currentLinkSprite.DestinationRectangle = new((int)Link.Instance.currentPosition.X, (int)Link.Instance.currentPosition.Y, 24, 32);
                            break;
                        case "bottom":
                            Link.Instance.currentPosition.Y -= knockbackDistance;
                            if (Link.Instance.currentPosition.Y > 542 - Link.Instance.currentLinkSprite.DestinationRectangle.Height)
                            {
                                Link.Instance.currentPosition.Y = 542 - Link.Instance.currentLinkSprite.DestinationRectangle.Height;
                                Link.Instance.isDamagedCounter = 10;
                            }
                            Link.Instance.currentLinkSprite.DestinationRectangle = new((int)Link.Instance.currentPosition.X, (int)Link.Instance.currentPosition.Y, 24, 32);
                            break;
                        case "left":
                            Link.Instance.currentPosition.X += knockbackDistance;
                            if (Link.Instance.currentPosition.X < 100)
                            {
                                Link.Instance.currentPosition.X = 100;
                                Link.Instance.isDamagedCounter = 10;
                            }
                            Link.Instance.currentLinkSprite.DestinationRectangle = new((int)Link.Instance.currentPosition.X, (int)Link.Instance.currentPosition.Y, 24, 32);
                            break;
                        case "right":
                            Link.Instance.currentPosition.X -= knockbackDistance;
                            if (Link.Instance.currentPosition.X > 700 - Link.Instance.currentLinkSprite.DestinationRectangle.Width)
                            {
                                Link.Instance.currentPosition.X = 700 - Link.Instance.currentLinkSprite.DestinationRectangle.Width;
                                Link.Instance.isDamagedCounter = 10;
                            }
                            Link.Instance.currentLinkSprite.DestinationRectangle = new((int)Link.Instance.currentPosition.X, (int)Link.Instance.currentPosition.Y, 24, 32);
                            break;
                        default:
                            break;
                    }
                    Link.Instance.UpdatePosition();
                }

                if (Link.Instance.isDamagedCounter > 120)
                {
                    Link.Instance.isDamagedCounter = 0;
                    Link.Instance.isDamaged = false;
                    Link.Instance.UpdatePosition();
                    Link.Instance.currentState.Redraw();
                }
            }
        }
    }
}