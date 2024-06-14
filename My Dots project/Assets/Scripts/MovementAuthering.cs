
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class MovementAuthering : MonoBehaviour
{


    public class Baker : Baker<MovementAuthering>
    {
        public override void Bake(MovementAuthering authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new Movement { movementVector = new float3(UnityEngine.Random.Range(-1f,1f),0,UnityEngine.Random.Range(-1f,1f))});
        }
    }
}

public partial struct Movement : IComponentData
{
   public float3 movementVector; 
}