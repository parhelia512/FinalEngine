// <copyright file="IMouse.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Input.Mouse
{
    public interface IMouse
    {
        bool IsButtonDown(MouseButton button);

        bool IsButtonPressed(MouseButton button);

        bool IsButtonReleased(MouseButton button);
    }
}