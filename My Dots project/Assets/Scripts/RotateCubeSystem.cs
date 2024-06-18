using Unity.Entities;
using Unity.Transforms;
using Unity.Burst;
using Unity.Jobs;
public partial struct RotateCubeSystem : ISystem
{
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        state.Enabled = false;
        return;
        /*foreach ((RefRW<LocalTransform> localTransform, RefRO<RotateSpeed> rotateSpeed) in SystemAPI.Query<RefRW<LocalTransform>, RefRO<RotateSpeed>>().WithNone<Player>())
        {
            float po = 1f;
            for (int i = 0; i < 1000000; i++)
            {
                po *= 2f;
                po /= 2f;
            }
            localTransform.ValueRW = localTransform.ValueRO.RotateY(rotateSpeed.ValueRO.value * SystemAPI.Time.DeltaTime * po);
        }*/

       // RotatingCubeJob rotatingCubeJob = new RotatingCubeJob { deltaTime = SystemAPI.Time.DeltaTime };

       // rotatingCubeJob.ScheduleParallel();
    } 

}

[BurstCompile]
[WithAll(typeof(RotatingCube))]
public partial struct RotatingCubeJob : IJobEntity
{
    public float deltaTime;
    public void Execute(ref LocalTransform localTransform, RotateSpeed rotateSpeed)
    {
        float po = 1f;
        for (int i = 0; i < 1000000; i++)
        {
            po *= 2f;
            po /= 2f;
        }
        localTransform = localTransform.RotateY(rotateSpeed.value * deltaTime * po);
    }
}
