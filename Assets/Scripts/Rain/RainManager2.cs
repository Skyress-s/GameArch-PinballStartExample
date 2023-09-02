using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class RainManager2 : MonoBehaviour
{
    [SerializeField] private GameObject rainDropPrefab;
    [SerializeField] private Vector2 spawnSize = Vector2.one * 10;

    void Start() {
        InvokeRepeating(nameof(SpawnRainDrop), 0.0f, 0.4f);
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Vector3 size = new Vector3(spawnSize.x, 0.1f, spawnSize.y);
        Gizmos.DrawWireCube(transform.position, size * 2);
    }

    Vector3 GetRandomRainDropPosition() {
        float x = Random.Range(-spawnSize.x, spawnSize.x);
        float z = Random.Range(-spawnSize.y, spawnSize.y);
        
        Transform trans = transform;
        trans.position = Vector3.one;
        
        Vector3 position = transform.position;
        position.x += x;
        position.z += z;
        return position;
    }
    
    void SpawnRainDrop() {
        GameObject rainDropGameObject = Instantiate(rainDropPrefab, 
            GetRandomRainDropPosition(), Quaternion.identity);
        
        Destroy(rainDropGameObject, 4f);
    }
    
    
}
