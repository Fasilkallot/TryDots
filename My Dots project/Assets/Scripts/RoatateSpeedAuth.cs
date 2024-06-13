using UnityEngine;
using Unity.Entities;
public class RoatateSpeedAuth : MonoBehaviour
{
    public float value;

    private class Baker : Baker<RoatateSpeedAuth>
    {
        public override void Bake(RoatateSpeedAuth authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new RotateSpeed { value = authoring.value }); 
        }
    }
}

public struct RotateSpeed : IComponentData
{
    public float value;
}
