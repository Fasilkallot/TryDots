using Unity.Entities;
using UnityEngine;

public class StunnedAuthering : MonoBehaviour
{

    public class Baker : Baker<StunnedAuthering>
    {
        public override void Bake(StunnedAuthering authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new Stunned());
            SetComponentEnabled<Stunned>(entity, false);
        }
    }
}

public struct Stunned : IComponentData, IEnableableComponent
{

}
