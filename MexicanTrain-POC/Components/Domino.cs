using Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace Components
{
    public class Domino : SpriteObject
    {
        public Domino(Game game, Texture2D spriteTexture, Rectangle collisionBox, bool isDraggable = false) : base(game, spriteTexture, collisionBox, isDraggable)
        {
            this.isVisible = true;
        }

        public static Domino CopyToDomino(SpriteObject spriteObject)
        {
            if (spriteObject == null)
            {
                throw new ArgumentNullException("Cannot convert a null object");
            }

            return new Domino(spriteObject.Game, spriteObject.spriteTexture, spriteObject.collisionBox, spriteObject.isDraggable);
        }
    }
}
