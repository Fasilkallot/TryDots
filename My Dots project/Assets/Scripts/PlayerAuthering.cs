using UnityEngine;
using Unity.Entities;
public class PlayerAuthering : MonoBehaviour
{

    public class Baker : Baker<PlayerAuthering>
    {
        public override void Bake(PlayerAuthering authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new Player());
        }
    }
}

public partial struct Player : IComponentData
{

}
