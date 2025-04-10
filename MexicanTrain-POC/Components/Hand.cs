﻿using MexicanTrain_POC;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
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
        private List<Domino> playerDominos = new List<Domino>();
        private int startingHandSize = 7;
        public Rectangle handRectangle = Rectangle.Empty;

        private TextureAtlas textureAtlas;
        private GraphicsDevice graphicsDevice;
        private GraphicsDeviceManager graphicsDeviceManager;
        public Game1 game { get; private set; }

        public Hand(TextureAtlas textureAtlas, GraphicsDevice graphicsDevice, GraphicsDeviceManager graphicsDeviceManager, Game1 game)
        { 
            this.textureAtlas = textureAtlas;
            this.graphicsDevice = graphicsDevice;
            this.graphicsDeviceManager = graphicsDeviceManager;
            this.game = game;

            CreateNewHand();
        }

        private void CreateNewHand()
        {
            CreateHandZone();
            
            for (int i = 0; i < startingHandSize; i++) 
            {
                SpriteObject dominoSpriteObject = this.textureAtlas.GenerateSpriteObjectFromAtlas(0, graphicsDevice, true);
                
                Domino domino = Domino.CopyToDomino(dominoSpriteObject, this);
                domino.UpdatePosition(new Vector2(handRectangle.X + (96 * i), handRectangle.Y - handRectangle.Height));
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

        private void CreateHandZone()
        {
            int x = 0;
            int y = this.graphicsDeviceManager.PreferredBackBufferHeight;
            int width = this.graphicsDeviceManager.PreferredBackBufferWidth;
            int height = (int)(this.graphicsDeviceManager.PreferredBackBufferHeight * .2);

            handRectangle = new Rectangle(x, y, width, height);
        }
    }
}
