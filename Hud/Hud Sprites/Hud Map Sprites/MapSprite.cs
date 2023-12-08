using LegendofZelda.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;


namespace Sprites
{

    
    public class MapSprite: ISprite
    {

        private List<Rectangle> sourceRectangles;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        private List<Vector2> destinationLocation;
        private Vector2 origin;
        private Texture2D texture;

        public MapSprite(int roomNumber, Texture2D texture)
        {

            this.texture = texture;
            sourceRectangle = new();
            sourceRectangles = new()
            {
                new(618, 108, 8, 8),
                new(528, 108, 8, 8),
                new(537, 108, 8, 8),
                new(627, 108, 8, 8),
                new(654, 108, 8, 8),
                new(600, 108, 8, 8),
                new(609, 108, 8, 8),
                new(654, 108, 8, 8),
                new(582, 108, 8, 8),
                new(528, 108, 8, 8),
                new(582, 108, 8, 8),
                new(609, 108, 8, 8),
                new(564, 108, 8, 8),
                new(537, 108, 8, 8),
                new(627, 108, 8, 8),
                new(573, 108, 8, 8),
                new(528, 108, 8, 8),
                new(519, 108, 8, 8)
            };

            destinationLocation = new();
            origin = new(475, 400);
            int dimension = 25;
            destinationLocation.Add(new(origin.X, origin.Y));
            destinationLocation.Add(new(origin.X - dimension, origin.Y));
            destinationLocation.Add(new(origin.X + dimension, origin.Y));
            destinationLocation.Add(new(origin.X, origin.Y-dimension));
            destinationLocation.Add(new(origin.X , origin.Y-2*dimension));
            destinationLocation.Add(new(origin.X - dimension, origin.Y-2*dimension));
            destinationLocation.Add(new(origin.X + dimension, origin.Y-2*dimension));
            destinationLocation.Add(new(origin.X, origin.Y-3* dimension));
            destinationLocation.Add(new(origin.X - dimension, origin.Y-3* dimension));
            destinationLocation.Add(new(origin.X -2* dimension, origin.Y-3* dimension));
            destinationLocation.Add(new(origin.X + dimension, origin.Y-3* dimension));
            destinationLocation.Add(new(origin.X + 2*dimension, origin.Y-3* dimension));
            destinationLocation.Add(new(origin.X + 2*dimension, origin.Y-4* dimension));
            destinationLocation.Add(new(origin.X + 3*dimension, origin.Y-4* dimension));
            destinationLocation.Add(new(origin.X, origin.Y-4* dimension));
            destinationLocation.Add(new(origin.X , origin.Y-5* dimension));
            destinationLocation.Add(new(origin.X - dimension, origin.Y-5*dimension));
            destinationLocation.Add(new(origin.X -2* dimension, origin.Y-5* dimension));

            sourceRectangle = sourceRectangles[roomNumber];
            destinationRectangle = new((int)destinationLocation[roomNumber].X, (int)destinationLocation[roomNumber].Y, dimension, dimension);

            
        }

        public Rectangle DestinationRectangle { get => Rectangle.Empty; set => sourceRectangle = value; }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }

        public Rectangle GetHitbox()
        {
            return Rectangle.Empty;
        }

        public void Update()
        {
            
        }

     

    }
}
