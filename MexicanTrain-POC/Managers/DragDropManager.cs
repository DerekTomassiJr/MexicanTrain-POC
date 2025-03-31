using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace Managers
{
    public class DragDropManager
    {
        private static readonly List<SpriteObject> _draggables = new List<SpriteObject>();
        private static SpriteObject _dragItem;

        public static void AddDraggable (SpriteObject draggable)
        {
            _draggables.Add(draggable);
        }

        private static void CheckDragStart() 
        { 
            if (InputManager.MouseClicked)
            {
                foreach (var draggable in _draggables)
                {
                    if (draggable.collisionBox.Contains(InputManager.MousePosition))
                    {
                        _dragItem = draggable;
                        break;
                    }
                }
            }
        }

        private static void CheckDragStop()
        {
            if (InputManager.MouseReleased)
            {
                _dragItem.HandleMouseRelease();
                _dragItem = null;
            }
        }

        public static void Update()
        {
            CheckDragStart();

            if (_dragItem != null)
            {
                _dragItem.UpdatePosition(InputManager.MousePosition);
                CheckDragStop();
            }
        }
    }
}
