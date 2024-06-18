using System;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public partial class PlayerShootingSystem : SystemBase
{
    //public event EventHandler OnShoot;
    protected override void OnCreate()
    {
        RequireForUpdate<Player>();
    }
    protected override void OnUpdate()
    {
        if (Input.GetKeyUp(KeyCode.Q))
        {
            Entity playerEntity = SystemAPI.GetSingletonEntity<Player>();
            EntityManager.SetComponentEnabled<Stunned>(playerEntity, false);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            Entity playerEntity = SystemAPI.GetSingletonEntity<Player>();
            EntityManager.SetComponentEnabled<Stunned>(playerEntity, true);
        }
        if(!Input.GetKeyDown(KeyCode.Space))
        {
            return;
        }

        SpawnCubeConfig spawnCubeConfig = SystemAPI.GetSingleton<SpawnCubeConfig>();

        EntityCommandBuffer entityCommandBuffer = new EntityCommandBuffer(WorldUpdateAllocator);

        foreach((RefRO<LocalTransform> localTransform, Entity entity) in SystemAPI.Query<RefRO<LocalTransform>>().WithAll<Player>().WithDisabled<Stunned>().WithEntityAccess()) 
        {
            Entity spawnedEntity = entityCommandBuffer.Instantiate(spawnCubeConfig.cubePrefabEntity);
            entityCommandBuffer.SetComponent(spawnedEntity, new LocalTransform
            {
                Position = localTransform.ValueRO.Position,
                Rotation = quaternion.identity,
                Scale = 1f
            });

            //  OnShoot.Invoke(entity,EventArgs.Empty);
            PlayerShootManager.instance.PlayerShoot(localTransform.ValueRO.Position);
        }

        entityCommandBuffer.Playback(EntityManager);
    }
}
