using UnityEngine;

public class GyroBoardController : MonoBehaviour
{
    [SerializeField] private float _maxRotation = 15f; // Maximum rotation angle in degrees
    [SerializeField] private float _speed = 100f;       // Speed of rotation
    [SerializeField] private float _returnSpeed = 2f;   // Speed at which the board returns to neutral position

    private float _currentXRotation = 0f;
    private float _currentZRotation = 0f;

    private void Start()
    {
        // Check if gyroscope is supported and enable it
        if (SystemInfo.supportsGyroscope)
        {
            Input.gyro.enabled = true;
        }
        else
        {
            Debug.LogWarning("Gyroscope not supported on this device.");
        }
    }

    private void FixedUpdate()
    {
        // Use accelerometer data
        Vector3 acceleration = Input.acceleration;
        Debug.Log("Acceleration : " + acceleration);

        // Use gyroscope data
        Vector3 gyroRotationRate = Input.gyro.rotationRateUnbiased;
        Debug.Log("Gyroscope Rotation Rate : " + gyroRotationRate);

        // Adjust rotation values based on accelerometer and gyroscope data
        float xRotation = acceleration.y * _speed * Time.fixedDeltaTime + gyroRotationRate.x * _speed * Time.fixedDeltaTime;
        float zRotation = acceleration.x * _speed * Time.fixedDeltaTime + gyroRotationRate.z * _speed * Time.fixedDeltaTime;

        // Update current rotations
        _currentXRotation += xRotation;
        _currentZRotation += zRotation;

        // Clamp rotations to max limits
        _currentXRotation = Mathf.Clamp(_currentXRotation, -_maxRotation, _maxRotation);
        _currentZRotation = Mathf.Clamp(_currentZRotation, -_maxRotation, _maxRotation);

        // Smoothly return to neutral position if there's no significant movement
        if (acceleration.sqrMagnitude < 1.1f)
        {
            _currentXRotation = Mathf.Lerp(_currentXRotation, 0f, Time.fixedDeltaTime * _returnSpeed);
            _currentZRotation = Mathf.Lerp(_currentZRotation, 0f, Time.fixedDeltaTime * _returnSpeed);
        }

        // Apply rotation to the board
        transform.localRotation = Quaternion.Euler(_currentXRotation, transform.localRotation.eulerAngles.y, -_currentZRotation);
    }
}