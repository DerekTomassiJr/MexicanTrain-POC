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
        private Hand hand;

        // This should be refactored to a builder design pattern but for proof of concept it is fine for now
        public Domino(Game game, Texture2D spriteTexture, Rectangle collisionBox, Hand hand, bool isDraggable = false) : base(game, spriteTexture, collisionBox, isDraggable)
        {
            this.isVisible = true;
            this.hand = hand;
        }

        public static Domino CopyToDomino(SpriteObject spriteObject, Hand hand)
        {
            if (spriteObject == null)
            {
                throw new ArgumentNullException("Cannot convert a null object");
            }

            return new Domino(spriteObject.Game, spriteObject.spriteTexture, spriteObject.collisionBox, hand, spriteObject.isDraggable);
        }

        public override void HandleMouseRelease()
        {
            Rectangle spawnRectangle = this.hand.handRectangle;

            DominoOutline boardCurrentOutline = this.hand.game._board.currentDominoOutline;
            Rectangle outlineRectangle = boardCurrentOutline.collisionBox;

            if (this.collisionBox.Intersects(outlineRectangle))
            {
                this.UpdatePosition(boardCurrentOutline.position);
            }
            else if (this.collisionBox.Intersects(spawnRectangle))
            {
                this.UpdatePosition(new Vector2(this.spawnLocation.X, this.spawnLocation.Y));
            }
        }
    }
}
