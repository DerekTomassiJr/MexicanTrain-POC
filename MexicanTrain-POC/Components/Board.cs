using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace Components
{
    public class Board
    {
        List<SpriteObject> playedDominos;
        SpriteObject currentDominoOutline;

        private TextureAtlas textureAtlas;
        private GraphicsDevice graphicsDevice;

        public Board(TextureAtlas textureAtlas, GraphicsDevice graphicsDevice)
        {
            this.textureAtlas = textureAtlas;
            this.graphicsDevice = graphicsDevice;

            InitializeBoard();
        }

        private void InitializeBoard() 
        {
            playedDominos = new List<SpriteObject>();

            currentDominoOutline = this.textureAtlas.GenerateSpriteObjectFromAtlas(1, graphicsDevice);
            currentDominoOutline.position = new Vector2(32, 0); //test code will be replaced in the future
            currentDominoOutline.isVisible = true;
        }

        public void RenderBoard(SpriteBatch spriteBatch)
        {
            currentDominoOutline.DrawSpriteObject(spriteBatch);
        }
    }
}
