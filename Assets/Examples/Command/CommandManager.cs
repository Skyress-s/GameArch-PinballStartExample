using System;
using System.Collections.Generic;
using UnityEngine;

namespace Examples.CommandPattern {
    
    // Example command patterns, will call a command if any every two seconds
    public class CommandManager : MonoBehaviour {
        // Singleton
        public static CommandManager Instance { get; private set; }
        
        
        Stack<ICommand> _commandStack = new Stack<ICommand>();
        
        private float _timer = 2f;
        public void AddCommand(ICommand command) {
            _commandStack.Push(command);
        }
        
        
        // Singleton setup
        private void Awake() {
            if (Instance == null) {
                Instance = this;
                return;
            }
            Destroy(this);
        }

        private void Update() {
            // Why is this bad?
            _timer -= Time.deltaTime;
            if (_timer <= 0) {
                Debug.Log("Try Executing command");
                if (_commandStack.Count > 0) {
                    _commandStack.Pop().Execute();
                }
                _timer = 2f;
            }
            
            return;
            // this is better,  much clearer to read
            _timer -= Time.deltaTime;
            bool bShouldExecuteCommand = false;
            if (_timer <= 0) {
                _timer = 2f;
                bShouldExecuteCommand = true;
            }

            if (bShouldExecuteCommand) {
                if (_commandStack.Count > 0) {
                    _commandStack.Pop().Execute();
                }
            }

            
            
        }
    }
}