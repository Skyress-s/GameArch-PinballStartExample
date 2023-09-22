using Examples.CommandPattern;
using UnityEngine;

namespace Examples.Command.Commands {
    public interface ITargetCommand : ICommand {
        public Transform Target { get; set; }
    }
}