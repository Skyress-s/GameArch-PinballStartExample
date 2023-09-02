using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Examples.SingeltonPattern {
    [DefaultExecutionOrder(-1000)] // ensure it runs before other scripts
    public class SomeSingletonClass : MonoBehaviour {
        // Bad version
        // public static SomeSingletonClass instance = null;

        public int difficultylevel = 3;

        // God version
        public static SomeSingletonClass Instance { get; private set; } = null;

        private void Awake() {
            // Set values and ensure only one in scene
            if (Instance == null) {
                Instance = this;
                return;
            }

            Destroy(this);
        }
    }
}