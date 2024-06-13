
using Unity.Entities;
using Unity.Transforms;
using Unity.Burst;
public partial struct RotateCubeSystem : ISystem
{
    [BurstCompile] 
  public void OnUpdate(ref SystemState state)
    {
        foreach((RefRW<LocalTransform> localTransform, RefRO<RotateSpeed> rotateSpeed) in SystemAPI.Query<RefRW<LocalTransform> , RefRO<RotateSpeed>>()){
            localTransform.ValueRW = localTransform.ValueRO.RotateY(rotateSpeed.ValueRO.value * SystemAPI.Time.DeltaTime);
        }
    }  
}
