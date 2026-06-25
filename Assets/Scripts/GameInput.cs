using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CroakGames
{
    public class GameInput : MonoBehaviour
    {
        public event Action Tapped;

        private void Update()
        {
            var pointer = Pointer.current;

            if (pointer != null && pointer.press.wasPressedThisFrame)
            {
                Tapped?.Invoke();
            }
        }
    }
}
