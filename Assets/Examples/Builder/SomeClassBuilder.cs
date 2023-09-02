using System.Collections.Generic;
using UnityEngine;

namespace Examples {
    public class SomeClassBuilder {
        private SomeFinishedClass someFinishedClass = new();
        
        public SomeFinishedClass Build() {
            return someFinishedClass;
        }
        
        public void SetSeats(int seats) {
            someFinishedClass.seats = seats;
        }
        
        public void SetTargetPositions(List<Vector3> targetPositions) {
            someFinishedClass.targetPositions = targetPositions;
        }
        
        public void AddTargetPosition(Vector3 targetPosition) {
            someFinishedClass.targetPositions.Add(targetPosition);
        }
        
        public void SetWheels(int wheels) {
            someFinishedClass.wheels = wheels;
        }
        
        public void SetMissiles(int missiles) {
            someFinishedClass.missiles = missiles;
        }
    }
}