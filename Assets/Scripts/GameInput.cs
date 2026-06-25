using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CroakGames
{
    public class GameInput : MonoBehaviour
    {
        public event Action Tapped;

        private InputAction _tap;

        private void Awake()
        {
            _tap = new InputAction(name: "Tap", type: InputActionType.Button, binding: "<Pointer>/press");
            _tap.performed += OnTapPerformed;
        }

        private void OnEnable()
        {
            _tap.Enable();
        }

        private void OnDisable()
        {
            _tap.Disable();
        }

        private void OnDestroy()
        {
            _tap.performed -= OnTapPerformed;
            _tap.Dispose();
        }

        private void OnTapPerformed(InputAction.CallbackContext context)
        {
            Tapped?.Invoke();
        }
    }
}
