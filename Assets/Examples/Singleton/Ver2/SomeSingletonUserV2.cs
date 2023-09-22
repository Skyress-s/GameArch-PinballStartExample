using System;
using UnityEngine;

public class SomeSingletonUserV2 : MonoBehaviour {
    private void Start() {
        Debug.Log(SomeSingletonV2.Instance.GetDifficulty());
    }
}