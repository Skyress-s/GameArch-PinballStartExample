using System;
using UnityEngine;

public class Flipper : MonoBehaviour {
    [SerializeField] private AnimationCurve animationCurve;
    private float _timer;
    private Rigidbody _rb;
    private void Awake() {
        _rb = GetComponent<Rigidbody>();
    }
    private void Update() {
        if (Input.GetKeyDown(KeyCode.A)) {
            _timer = 0;
        }
        _timer += Time.deltaTime;
    }

    private void FixedUpdate() {
        // Rotatsjon logik
        // Instead of rotating object using transform.rotation / transform.localEulerAngles
        // we use rigidbody.MoveRotation. This rotates the object in the physicsstep (Fixed Update) and ensures 
        // other raindrops / pinballs dont clip through and receives velocity!
        _rb.MoveRotation(Quaternion.Euler(0,0,animationCurve.Evaluate(_timer) * 90f));
    }
}
