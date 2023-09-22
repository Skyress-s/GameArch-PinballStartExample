using Examples.Command.Commands;
using UnityEngine;

namespace Examples.CommandPattern.Commands {
    public class MoveCommand : ITargetCommand {
        private Vector3 _offset;
        public MoveCommand(Vector3 offset, Transform target) {
            _offset = offset;
            Target = target;
        }
        public void Execute() {
            Target.transform.position += _offset;
        }

        public Transform Target { get; set; }
    }
}