using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class RainManager : MonoBehaviour {
    
}


/*
 
    [SerializeField] private GameObject rainDropPrefab;
        
    [SerializeField] Vector3 size = new Vector3(10, 10, 10); 
    [SerializeField] private int rainDropCount = 100;
    [SerializeField] private static int currentRainDrops;
    private void Update() {
    }

    Vector3 GetRandomPosition() {
        Vector3 position;
        position.x = Random.Range(-size.x, size.x);
        position.y = Random.Range(-size.y, size.y);
        position.z = Random.Range(-size.z, size.z);
        return position;
    }

    void SpawnRainDrop(){
    }
        
       
    private void OnDrawGizmosSelected() {
        Gizmos.DrawWireCube(transform.position, size);
    }
 */