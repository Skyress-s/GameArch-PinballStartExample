using System;
using UnityEngine;

namespace ClassLesson {
    public class PrintSinusCommand : ICommand {
        public void Execute() {
            Debug.Log(MathF.Sin(Mathf.PI*3f/2f));
            
        }

    }
}