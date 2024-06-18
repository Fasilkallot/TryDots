using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPopUp : MonoBehaviour
{
    float _destroyTime = 1f;

    private void Update()
    {
        float moveSpeed = 2f;
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);

        _destroyTime -= Time.deltaTime;
        moveSpeed += Time.deltaTime;

        if(_destroyTime <= 0)
        {
            Destroy(gameObject);
        }

    }
}
