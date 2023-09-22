using System;
using ClassLesson;
using UnityEngine;

public class SomeSingletonV2 : MonoBehaviour {
    public static SomeSingletonV2 Instance { get; private set; }

    public int difficulty;
    

    private void Awake() {
        if (Instance != null && Instance != this) {
            ICommand command;
            
        }
        if (Instance == null) {
            // SetInstance(this);   
            Instance = this;
        }
        else 
        {
            Destroy(this);
        }
    }
    
    public int GetDifficulty() {
        return difficulty;
    }

    /* c++ way
    public static SomeSingletonV2 GetInstance() {
        return Instance;
    }

    private void SetInstance(SomeSingletonV2 newInstance) {
        Instance = newInstance;
    }
    */

    private void Reset() {
        var singleton = FindObjectOfType<SomeSingletonV2>();
        if (singleton == null) {
            Instance = this;
        }
        else {
            DestroyImmediate(this);
        }
    }

    
    
    // Only relevant if you use Reload Domain settings
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
    private static void Reinitialize() {
        Instance = null;
    }
        
}
