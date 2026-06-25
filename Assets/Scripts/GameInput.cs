using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using ETouch = UnityEngine.InputSystem.EnhancedTouch;

namespace CroakGames
{
    public class GameInput : MonoBehaviour
    {
        public event Action Tapped;

        private bool _mouseWasPressed;

        private void OnEnable()
        {
            EnhancedTouchSupport.Enable();
        }

        private void OnDisable()
        {
            EnhancedTouchSupport.Disable();
        }

        private void Update()
        {
            foreach (var touch in ETouch.Touch.activeTouches)
            {
                if (touch.phase == UnityEngine.InputSystem.TouchPhase.Began)
                {
                    Tapped?.Invoke();
                    return;
                }
            }

            var mouse = Mouse.current;
            if (mouse == null)
            {
                return;
            }

            var pressed = mouse.leftButton.isPressed;

            if (pressed && !_mouseWasPressed)
            {
                Tapped?.Invoke();
            }

            _mouseWasPressed = pressed;
        }
    }
}
