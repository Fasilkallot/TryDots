
using Unity.Entities;
using UnityEngine;

public class SpawnCubeConfigAuthering : MonoBehaviour
{
    public GameObject cubePrefab;
    public int spawnAmount;

    public class Baker : Baker<SpawnCubeConfigAuthering>
    {
        public override void Bake(SpawnCubeConfigAuthering authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.None);
            AddComponent(entity,new SpawnCubeConfig { cubePrefabEntity = GetEntity( authoring.cubePrefab, TransformUsageFlags.Dynamic) , spawnAmount = authoring.spawnAmount });
        }
    }
}
public struct SpawnCubeConfig : IComponentData
{
    public Entity cubePrefabEntity;
    public int spawnAmount;
}