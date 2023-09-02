using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionExample : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        // Fstring formatting!
        Debug.LogWarning($"this object collider with {other.gameObject.name}");
    }

    private void OnTriggerEnter(Collider other) {
        
        Debug.LogWarning($"this object triggers with {other.gameObject.name}");
    }
}