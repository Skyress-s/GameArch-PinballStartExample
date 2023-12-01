using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace EXAM {
    public class InputHandler : MonoBehaviour {
        [SerializeField] private GeneralInput _generalInput;

        private void Awake() {
            _generalInput = new GeneralInput();
            _generalInput.BasicInput.MOVE.ReadValue<Vector2>();
        }

        private void OnEnable() {
            _generalInput.Enable();
        }

        private void OnDisable() {
            _generalInput.Disable();
        }
    }
}