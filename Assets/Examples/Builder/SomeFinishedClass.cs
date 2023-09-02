using System.Collections.Generic;
using UnityEngine;

// Builder pattern
// Useful for complex classes where the configuration is complex and or requires a lot of parameters.

namespace Examples {
    public class SomeFinishedClass {
        internal int seats;
        internal List<Vector3> targetPositions;
        internal int wheels;
        internal int missiles;
        
        
        private int currentTargetIndex = 0;
        // Functions
        public void CycleTarget() {
            currentTargetIndex++;
            if (currentTargetIndex >= targetPositions.Count) {
                currentTargetIndex = 0;
            }
        }
        
        public void FireMissileAtTarget() {
            // logic for firing missile
        }
        
        
    }
}