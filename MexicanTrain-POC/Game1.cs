using HappyHourPhysicsTest.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace MexicanTrain_POC
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private TextureAtlas _itemTextures;
        private List<SpriteObject> _sprites; 

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _graphics.IsFullScreen = false;
            _graphics.PreferredBackBufferWidth = 960;
            _graphics.PreferredBackBufferHeight = 640;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            Texture2D itemTiles = Content.Load<Texture2D>(Constants.MexicanTrainTextureAtalas);
            _itemTextures = new TextureAtlas(this, itemTiles, 32, 32);

            LoadSprites();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(1, 127, 1));

            _spriteBatch.Begin();
            this.DrawSpriteObjects();
            _spriteBatch.End();

            base.Draw(gameTime);
        }

        private void LoadSprites()
        {
            SpriteObject domino = this._itemTextures.GenerateSpriteObjectFromAtlas(0, GraphicsDevice);
            domino.isVisible = true;

            SpriteObject dominoOutline = this._itemTextures.GenerateSpriteObjectFromAtlas(1, GraphicsDevice);
            dominoOutline.isVisible = true;

            _sprites = new List<SpriteObject> { domino, dominoOutline };
        }

        private void DrawSpriteObjects()
        {
            foreach (SpriteObject spriteObject in _sprites) 
            {
                spriteObject.DrawSpriteObject(_spriteBatch);
            }
        }

        /// <summary>
        /// Debug function to help show rectangle bounds
        /// </summary>
        /// <param name="texture"></param>
        /// <param name="borderWidth"></param>
        /// <param name="borderColor"></param>
        public static void CreateBorder(Texture2D texture, int borderWidth, Color borderColor)
        {
            Color[] colors = new Color[texture.Width * texture.Height];

            for (int x = 0; x < texture.Width; x++)
            {
                for (int y = 0; y < texture.Height; y++)
                {
                    bool colored = false;
                    for (int i = 0; i <= borderWidth; i++)
                    {
                        if (x == i || y == i || x == texture.Width - 1 - i || y == texture.Height - 1 - i)
                        {
                            colors[x + y * texture.Width] = borderColor;
                            colored = true;
                            break;
                        }
                    }

                    if (colored == false)
                        colors[x + y * texture.Width] = Color.Transparent;
                }
            }

            texture.SetData(colors);
        }
    }
}
