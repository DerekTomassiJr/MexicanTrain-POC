﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class SpriteObject : GameComponent
    {
        public Texture2D spriteTexture;
        public Rectangle collisionBox;
        public Rectangle spawnLocation;
        public Vector2 position;
        public bool isVisible;

        public SpriteObject(Game game, Texture2D spriteTexture, Rectangle collisionBox) : base(game)
        {
            this.spriteTexture = spriteTexture;
            this.collisionBox = collisionBox;
            spawnLocation = new Rectangle(0, 0, 0, 0);
            position = new Vector2(0, 0);
        }

        public SpriteObject(Game game, Texture2D spriteTexture, Rectangle collisionBox, Rectangle spawnLocation) : base(game)
        {
            this.spriteTexture = spriteTexture;
            this.collisionBox = collisionBox;
            this.spawnLocation = spawnLocation;
            position = GenerateObjectSpawnPosition();
        }

        public void DrawSpriteObject(SpriteBatch spriteBatch)
        {
            if (!isVisible)
            {
                return;
            }

            Rectangle destination = new Rectangle((int)position.X, (int)position.Y, 128, 128); //Test code
            spriteBatch.Draw(spriteTexture, destination, Color.White);
        }

        private Vector2 GenerateObjectSpawnPosition()
        {
            Random random = new Random();
            int spawnX = 0;
            int spawnY = 0;

            return new Vector2(spawnX, spawnY);
        }
    }
}
