
using Unity.Entities;
using UnityEngine;

public class RotateCubeAuth : MonoBehaviour
{
    public class Baker : Baker<RotateCubeAuth>
    {
        public override void Bake(RotateCubeAuth authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.None);
            AddComponent(entity, new RotatingCube());
        }
    }
}

public struct RotatingCube : IComponentData
{

}
