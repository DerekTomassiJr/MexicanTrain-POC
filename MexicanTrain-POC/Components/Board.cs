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
        public List<Domino> playedDominos { get; set; }
        public DominoOutline currentDominoOutline { get; private set; }

        private TextureAtlas textureAtlas;
        private GraphicsDevice graphicsDevice;
        private GraphicsDeviceManager graphicsDeviceManager;

        public Board(TextureAtlas textureAtlas, GraphicsDevice graphicsDevice, GraphicsDeviceManager graphicsDeviceManager)
        {
            this.textureAtlas = textureAtlas;
            this.graphicsDevice = graphicsDevice;
            this.graphicsDeviceManager = graphicsDeviceManager;

            InitializeBoard();
        }

        private void InitializeBoard() 
        {
            playedDominos = new List<Domino>();

            SpriteObject dominoOutlineSpriteObject = this.textureAtlas.GenerateSpriteObjectFromAtlas(1, graphicsDevice);

            currentDominoOutline = DominoOutline.CopyToDominoOutline(dominoOutlineSpriteObject);
            currentDominoOutline.UpdatePosition(new Vector2(this.graphicsDeviceManager.PreferredBackBufferWidth / 3 + 96, this.graphicsDeviceManager.PreferredBackBufferHeight / 4)); //test code will be replaced in the future
            currentDominoOutline.isVisible = true;
        }

        public void RenderBoard(SpriteBatch spriteBatch)
        {
            currentDominoOutline.DrawSpriteObject(spriteBatch);
        }
    }
}
