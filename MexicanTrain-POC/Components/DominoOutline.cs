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
    public class DominoOutline : SpriteObject
    {
        public DominoOutline(Game game, Texture2D spriteTexture, Rectangle collisionBox, bool isDraggable = false) : base(game, spriteTexture, collisionBox, isDraggable)
        {
        
        }

        public static DominoOutline CopyToDominoOutline(SpriteObject spriteObject)
        {
            return new DominoOutline(spriteObject.Game, spriteObject.spriteTexture, spriteObject.collisionBox, spriteObject.isDraggable);
        }
    }
}
