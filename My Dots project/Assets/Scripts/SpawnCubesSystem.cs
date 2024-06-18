using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
public partial class SpawnCubesSystem : SystemBase
{
    protected override void OnCreate()
    {
        RequireForUpdate<SpawnCubeConfig>();
    }

    protected override void OnUpdate()
    {
        // to make this function only called onece
        this.Enabled = false;

        SpawnCubeConfig spawnCubeConfig = SystemAPI.GetSingleton<SpawnCubeConfig>();

        for(int i = 0; i < spawnCubeConfig.spawnAmount; i++)
        {
            Entity spawnedEntity =  EntityManager.Instantiate(spawnCubeConfig.cubePrefabEntity);
            SystemAPI.SetComponent(spawnedEntity, new LocalTransform { 
                Position = new float3(UnityEngine.Random.Range(-10f,+5),0.6f, UnityEngine.Random.Range(-4f,+7)),
                Rotation =quaternion.identity,
                Scale = 1f});
        
        }

    }
}
