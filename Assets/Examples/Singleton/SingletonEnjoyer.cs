using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Examples.SingeltonPattern {
    
    public class SingletonEnjoyer : MonoBehaviour {
        
        Vector3 _startPosition;
        [SerializeField] private float ocilateDistance = 3f;
        private void Start() {
            if (SomeSingletonClass.Instance.difficultylevel == 3) {
                Debug.Log("This is difficult");   
            }
     
            // cant do
            // SomeSingletonClass.Instance = null;


            _startPosition = transform.position;
        }

        private void Update() {
            float speed = SomeSingletonClass.Instance.difficultylevel;
            
            transform.position = _startPosition + transform.up * ocilateDistance * Mathf.Sin(Time.time * speed);
        }
    }
}