
using UnityEngine;

public class BallControl : MonoBehaviour
{
    public bool IsFlat = true;
    public float speed = 10f;
    private Rigidbody _rb;
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 accVal = Input.acceleration;
        if (IsFlat) 
            accVal = Quaternion.Euler(90,0,0) * accVal;

        accVal *= speed*Time.fixedDeltaTime;

        _rb.AddForce(accVal);
    }
}
