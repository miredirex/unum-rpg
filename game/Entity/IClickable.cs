using SFML.System;

namespace unum
{
    public interface IClickable
    {
        /// <summary>
        /// Mouse left button was clicked within this object bounds
        /// </summary>
        /// <param name="mousePos">Position of the mouse at the moment it was clicked</param>
        void OnMouseClickWithin(Vector2i mousePos);
    }
}
