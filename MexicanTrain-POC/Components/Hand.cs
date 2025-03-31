using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace Components
{
    public class Hand
    {
        private List<SpriteObject> playerDominos = new List<SpriteObject>();
        private int startingHandSize = 7;

        private TextureAtlas textureAtlas;
        private GraphicsDevice graphicsDevice;

        public Hand(TextureAtlas textureAtlas, GraphicsDevice graphicsDevice)
        { 
            this.textureAtlas = textureAtlas;
            this.graphicsDevice = graphicsDevice;

            CreateNewHand();
        }

        private void CreateNewHand()
        {
            for (int i = 0; i < startingHandSize; i++) 
            {
                SpriteObject domino = this.textureAtlas.GenerateSpriteObjectFromAtlas(0, graphicsDevice);
                domino.isVisible = true;

                playerDominos.Add(domino);
            }
        }

        public void RenderHand(SpriteBatch spriteBatch)
        {
            foreach (SpriteObject domino in playerDominos)
            {
                domino.DrawSpriteObject(spriteBatch);
            }
        }
    }
}
