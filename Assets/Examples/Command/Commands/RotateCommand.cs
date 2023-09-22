using Examples.CommandPattern;
using UnityEngine;

namespace Examples.Command.Commands {
    public class RotateCommand : ICommand {
        private Vector3 _rotateBy;
        public RotateCommand(Vector3 rotateBy) {
            _rotateBy = rotateBy;
        }
        public void Execute() {
            
        }
    }
}