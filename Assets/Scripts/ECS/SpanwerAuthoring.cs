using Unity.Entities;
using UnityEngine;

namespace ECS {
    public class SpawnerAuthoring : MonoBehaviour {
        public GameObject prefab;
        public float spawnRate;
        
        public class SpawnerBaker : Baker<SpawnerAuthoring> {
                public override void Bake(SpawnerAuthoring authoring) {
                var entity = GetEntity(TransformUsageFlags.None);
                AddComponent(entity, new Spawner {
                    Prefab = GetEntity(authoring.prefab, TransformUsageFlags.Dynamic),
                    SpawnPosition = authoring.transform.position,
                    NextSpawnTime = 0f,
                    SpawnRate = authoring.spawnRate,
                    count = 1
                });
            }
        }
    }
}