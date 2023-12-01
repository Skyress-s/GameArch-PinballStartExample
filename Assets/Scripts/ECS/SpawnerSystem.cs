using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace ECS {
    public partial struct SpawnerSystem : ISystem {
        [BurstCompile]
        public void OnCreate(ref SystemState state) {
            
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state) {
            /*
            // Non mutithreaded version
            foreach (RefRW<Spawner> spawner in SystemAPI.Query<RefRW<Spawner>>())
            {
                ProcessSpawner(ref state, spawner);
            }
        */
            EntityCommandBuffer.ParallelWriter ecb = GetEntityCommandBuffer(ref state);

            // Creates a new instance of the job, assigns the necessary data, and schedules the job in parallel.
            new ProcessSpawnerJob
            {
                ElapsedTime = SystemAPI.Time.ElapsedTime,
                Ecb = ecb,
                DeltaTime = SystemAPI.Time.DeltaTime
            }.ScheduleParallel();
        }

        private EntityCommandBuffer.ParallelWriter GetEntityCommandBuffer(ref SystemState state)
        {
            var ecbSingleton = SystemAPI.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>();
            var ecb = ecbSingleton.CreateCommandBuffer(state.WorldUnmanaged);
            return ecb.AsParallelWriter();
        }

        private void ProcessSpawner(ref SystemState state, RefRW<Spawner> spawner) {
            // If the next spawn time has passed.
            if (spawner.ValueRO.NextSpawnTime < SystemAPI.Time.ElapsedTime) {
                // Spawns a new entity and positions it at the spawner.
                Entity newEntity = state.EntityManager.Instantiate(spawner.ValueRO.Prefab);
                // LocalPosition.FromPosition returns a Transform initialized with the given position.
                state.EntityManager.SetComponentData(newEntity,
                    LocalTransform.FromPosition(spawner.ValueRO.SpawnPosition));

                // Resets the next spawn time.
                spawner.ValueRW.NextSpawnTime = (float)SystemAPI.Time.ElapsedTime + spawner.ValueRO.SpawnRate;
            }
        }
        [BurstCompile]
        public partial struct ProcessSpawnerJob : IJobEntity
        {
            public EntityCommandBuffer.ParallelWriter Ecb;
            public double ElapsedTime;
            public float DeltaTime;

            // IJobEntity generates a component data query based on the parameters of its `Execute` method.
            // This example queries for all Spawner components and uses `ref` to specify that the operation
            // requires read and write access. Unity processes `Execute` for each entity that matches the
            // component data query.
            private void Execute([ChunkIndexInQuery] int chunkIndex, ref Spawner spawner) {
                spawner.NextSpawnTime -= DeltaTime;
                    // Entity newEntit = Ecb.Instantiate(chunkIndex, spawner.Prefab);
                    // Ecb.SetComponent(chunkIndex, newEntit, LocalTransform.FromPosition(spawner.SpawnPosition));
                while (spawner.NextSpawnTime < 0) {
                    
                    Entity newEntity = Ecb.Instantiate(chunkIndex, spawner.Prefab);
                    // float floatElapsedTime = (float)spawner.count / 10f;
                    // float dist = floatElapsedTime * 0.3f;
                    // float spinSpeed = floatElapsedTime * 10f;
                    // float3 pos = new float3(math.cos(spinSpeed)*dist, math.sin(spinSpeed) * dist, 0);
                    float time = (float)spawner.count / 10f;
                    float radius = time * 0.3f;
                    float thetha =  (100f * time) % (math.PI);
                    float tau = time % (2f * math.PI);
                    float x = radius * math.sin(thetha) * math.cos(tau);
                    float y = radius * math.sin(thetha) * math.sin(tau);
                    float z = radius * math.cos(thetha);
                    
                    float3 pos = new float3(x,y,z);
                    Ecb.SetComponent(chunkIndex, newEntity, LocalTransform.FromPosition(pos));

                    // Resets the next spawn time.
                    // spawner.NextSpawnTime = (float)ElapsedTime + spawner.SpawnRate;
                    spawner.NextSpawnTime += spawner.SpawnRate;
                    spawner.count += 1;
                }
                return;
                // If the next spawn time has passed.
                if (spawner.NextSpawnTime < ElapsedTime)
                {
                    
                    // Spawns a new entity and positions it at the spawner.
                    Entity newEntity = Ecb.Instantiate(chunkIndex, spawner.Prefab);
                    Ecb.SetComponent(chunkIndex, newEntity, LocalTransform.FromPosition(spawner.SpawnPosition));

                    // Resets the next spawn time.
                    spawner.NextSpawnTime = (float)ElapsedTime + spawner.SpawnRate;
                    spawner.count += 1;
                }
            }
        }
        [BurstCompile]
        public void OnDestroy(ref SystemState state) {

        }
    }
}