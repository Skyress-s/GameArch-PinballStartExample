using System;
using System.Collections.Generic;
using UnityEngine;

namespace ClassLesson {
    public class CommandManager : MonoBehaviour {
        private Stack<ICommand> commands = new Stack<ICommand>();

        private void Awake() {
            commands.Push(new PrintPI());
            commands.Push(new PrintSinusCommand());
            
            InvokeRepeating("DoCommand", 0f, 2f);
        }

        private void DoCommand() {
            if (commands.Count != 0) {
                ICommand command = commands.Pop();
                command.Execute();
            }
        }
        
    }
}