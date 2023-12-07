using System;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using UnityEngine.UIElements;
using Utility;

namespace EXAM {
    [RequireComponent(typeof(Rigidbody))]
    public class AdvancedMovePlayer : MonoBehaviour,  GeneralInput.IBasicInputActions {
        [Header("References")]
        [SerializeField] private Transform _cameraBoom;


        private Rigidbody _rb;
        private CapsuleCollider _capsuleCollider;
        
        [Header("Config")]
        
        [Range(0.01f, 10f)]
        [SerializeField] private float lookSensetivity = 1f;

        [Range(1f, 5f)]
        [SerializeField] private float sprintModifier = 1.5f;
        
        private float SprintMod {
            get {
                if (_sprintInput > 0.5f) {
                    return sprintModifier;
                }

                return 1f;
            }
        }
        
        
        [Range(1f, 5f)]
        [SerializeField] private float maxSpeed = 5.5f;
        
        [Range(1, 50)]
        [SerializeField] float acceleration = 15f;
        
        [Range(1, 20)]
        [SerializeField] float jumpImpulse = 15f;
        
        
        private Vector2 _moveInput;
        private float _jumpInput;
        private float _crouchInput;
        private Vector2 _lookInput;
        private float _sprintInput;

        private void Awake() {
            // _controller = GetComponent<CharacterController>();
            _rb = GetComponent<Rigidbody>();
            _capsuleCollider = GetComponent<CapsuleCollider>();
        }

        private void Update() {
            // Rotation
            _cameraBoom.transform.localEulerAngles = new Vector3(_lookInput.y, _lookInput.x, 0);
            //

            
            
            if (!IsGrounded()) {
                _rb.drag = 0f;
                return;
            }

            _rb.drag = _moveInput.magnitude < 0.01f ? 10f : 0f;
            Vector3 right = _cameraBoom.right.RemY().normalized;
            Vector3 forward = _cameraBoom.forward.RemY().normalized;
            
            Vector2 moveInput = _moveInput.normalized;
            // moveInput *= SprintMod;
            
            Vector3 worldOffset = right * moveInput.x + forward * moveInput.y;
            
            _rb.AddForce(worldOffset * acceleration * SprintMod, ForceMode.Acceleration);

            if (_rb.velocity.RemY().sqrMagnitude > maxSpeed * maxSpeed) {
                _rb.AddForce(-_rb.velocity.RemY().normalized * acceleration * SprintMod * 1.2f);
            }


            
            
            return;
            
            float directionX = Vector3.Dot(_cameraBoom.right, _rb.velocity);
            float directionZ = Vector3.Dot(_cameraBoom.forward, _rb.velocity);
            
            void AddBreakingForce(Vector3 dir) {
                _rb.AddForce(dir * acceleration, ForceMode.Acceleration);
            }
            const float k_cutoff = 0.2f;
            
            if (directionX > k_cutoff && moveInput.x <= 0) {
                AddBreakingForce(-right);
            }
            else if (directionX < -k_cutoff && moveInput.x >= 0) {
                AddBreakingForce(right);   
            }
            
            if (directionZ > k_cutoff && moveInput.y <= 0) {
                AddBreakingForce(-forward);
            }
            else if (directionZ < -k_cutoff && moveInput.y >= 0) {
                AddBreakingForce(forward);   
            }
            
            //
            // worldOffset.y += _jumpInput - _crouchInput;
            // _controller.Move(worldOffset * Time.deltaTime);

            // Adding gravity
            // _controller.Move(Physics.gravity * Time.deltaTime);

            // transform.Translate(worldOffset * Time.deltaTime, Space.World);
        }

        public void OnMove(InputAction.CallbackContext context) {
            _moveInput = context.ReadValue<Vector2>();
        }

        public void OnJump(InputAction.CallbackContext context) {
            Debug.Log($"Input : {context.started}");
            if (context.started && IsGrounded()) {
                Debug.Log("haha!");
                _rb.AddForce(Vector3.up * jumpImpulse, ForceMode.VelocityChange);
            }
            _jumpInput = context.ReadValue<float>();
        }

        public void OnCrouch(InputAction.CallbackContext context) {
            _crouchInput = context.ReadValue<float>();
        }

        public void OnLook(InputAction.CallbackContext context) {
            Vector2 input = context.ReadValue<Vector2>();
            input.y *= -1f;
            input *= lookSensetivity;
            _lookInput += input;
            _lookInput.y = Mathf.Clamp(_lookInput.y, -89.5f, 89.5f);
        }

        public void OnSprint(InputAction.CallbackContext context) {
            _sprintInput = context.ReadValue<float>() * sprintModifier;
        }

        public bool IsGrounded() {
            Vector3 start = transform.position;
            start.y -= _capsuleCollider.height / 2f - 0.05f;
            Vector3 end = start + Vector3.down * 0.1f;
            Debug.DrawLine(start, end, Color.green, 1f);
            return Physics.Raycast(start, Vector3.down, 0.1f);
        }
    }
}