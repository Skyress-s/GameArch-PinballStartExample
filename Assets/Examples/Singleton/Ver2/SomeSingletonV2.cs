using System;
using UnityEngine;

public class SomeSingletonV2 : MonoBehaviour {
    public static SomeSingletonV2 Instance;

    public int difficulty;

    private void Awake() {
        Instance = this;
    }

    public int GetDifficulty() {
        return difficulty;
    }
        
}
