// <copyright file="IKeyboard.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Input.Keyboard
{
    //// TODO: Key Modifiers

    public interface IKeyboard
    {
        bool IsKeyDown(Key key);

        bool IsKeyPressed(Key key);

        bool IsKeyReleased(Key key);
    }
}