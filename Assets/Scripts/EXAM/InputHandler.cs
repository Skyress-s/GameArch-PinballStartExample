using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace EXAM {
    public class InputHandler : MonoBehaviour  { 
        private GeneralInput _generalInput;

        private GeneralInput.IBasicInputActions _currentPlayer = null;

        public void SetCurrentPlayer(GeneralInput.IBasicInputActions newPlayer) {
            // if(_currentPlayer != null)
            _generalInput.BasicInput.RemoveCallbacks(_currentPlayer);
            
            _generalInput.BasicInput.AddCallbacks(newPlayer);
        }
        
        
        
        
        
        private void Awake() {
            _generalInput = new GeneralInput();
             SetCurrentPlayer(FindObjectOfType<AdvancedMovePlayer>());

             Cursor.visible = false;
             Cursor.lockState = CursorLockMode.Locked;
        }

        private void OnEnable() {
            _generalInput.Enable();
        }

        private void OnDisable() {
            _generalInput.Disable();
        }
    }
}