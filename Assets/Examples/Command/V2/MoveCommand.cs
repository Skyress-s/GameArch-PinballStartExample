using UnityEngine;

namespace ClassLesson {
    public class PrintPI : ICommand {
        public void Execute() {
            Debug.Log(Mathf.PI);
        }

    }
}