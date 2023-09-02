using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Examples.SingeltonPattern {
    public class SingletonUser : MonoBehaviour {
        private float timer = k_timerMax;
        private const float k_timerMax = 0.8f;
        private void Start() {
            // can do this
            if (SomeSingletonClass.Instance.difficultylevel == 3) {
                Debug.Log("This is difficult");
            }

            if (SomeSingletonClass.Instance.difficultylevel == 2) {
                Debug.Log("This is medium");
            }
            
            // bad 
            // SomeSingletonClass.Instance = null;
        }

        private void Update() {
            timer -= Time.deltaTime;
            if (timer <= 0) {
                timer = k_timerMax * SomeSingletonClass.Instance.difficultylevel;
                var a = Random.insideUnitCircle * 4f;

                transform.position = new Vector3(a.x, a.y, 0);
            }
        }
    }
}