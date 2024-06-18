
using System;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

public class PlayerShootManager : MonoBehaviour
{
    [SerializeField] GameObject _shootPopup;
    private void Start()
    {
        PlayerShootingSystem playerShootingSystem = World.DefaultGameObjectInjectionWorld.GetExistingSystemManaged<PlayerShootingSystem>();

        playerShootingSystem.OnShoot += PlayerShootingSystem_OnShoot;
    }

    private void PlayerShootingSystem_OnShoot(object sender, EventArgs e)
    {
        Entity playerEntity = (Entity)sender;
        LocalTransform playerPosition = World.DefaultGameObjectInjectionWorld.EntityManager.GetComponentData<LocalTransform>(playerEntity);
        Instantiate(_shootPopup, playerPosition.Position, Quaternion.identity);
    }
}
