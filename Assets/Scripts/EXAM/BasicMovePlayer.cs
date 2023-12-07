using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using Utility;

namespace EXAM {
    public class BasicMovePlayer : MonoBehaviour,  GeneralInput.IBasicInputActions {
        [Header("References")]
        [SerializeField] private Transform _cameraBoom;


        // private CharacterController _controller;
        // private Vector3 _velocity;
        
        
        [Header("Config")]
        
        [Range(0.01f, 10f)]
        [SerializeField] private float lookSensetivity = 1f;

        [Range(1f, 5f)]
        [SerializeField] private float sprintModifier = 1.5f;
        
        private Vector2 _moveInput;
        private float _jumpInput;
        private float _crouchInput;
        private Vector2 _lookInput;
        private float _sprintInput;

        private void Awake() {
            // _controller = GetComponent<CharacterController>();
        }

        private void Update() {
            
            _cameraBoom.transform.localEulerAngles = new Vector3(_lookInput.y, _lookInput.x, 0);

            Vector2 moveInput = _moveInput.normalized;
            if (_sprintInput > 1f) {
                moveInput *= sprintModifier;
            }
            Vector3 worldOffset = _cameraBoom.right * moveInput.x + _cameraBoom.forward.RemY().normalized * moveInput.y;
            
            worldOffset.y += _jumpInput - _crouchInput;
            // _controller.Move(worldOffset * Time.deltaTime);
            
            // Adding gravity
            // _controller.Move(Physics.gravity * Time.deltaTime);

            transform.Translate(worldOffset * Time.deltaTime, Space.World);
        }

        public void OnMove(InputAction.CallbackContext context) {
            _moveInput = context.ReadValue<Vector2>();
        }

        public void OnJump(InputAction.CallbackContext context) {
            _jumpInput = context.ReadValue<float>();
        }

        public void OnCrouch(InputAction.CallbackContext context) {
            _crouchInput = context.ReadValue<float>();
        }

        public void OnLook(InputAction.CallbackContext context) {
            Vector2 input = context.ReadValue<Vector2>();
            input.y *= -1f;
            input.y = Mathf.Clamp(input.y, -89.5f, 89.5f);
            _lookInput += input * lookSensetivity;
        }

        public void OnSprint(InputAction.CallbackContext context) {
            _sprintInput = context.ReadValue<float>() * sprintModifier;
        }
    }
}