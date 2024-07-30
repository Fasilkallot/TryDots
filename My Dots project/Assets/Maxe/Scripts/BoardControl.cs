using UnityEngine;
using UnityEngine.InputSystem;

public class BoardControl : MonoBehaviour
{
    [SerializeField] private InputActionReference _rotateAction;
    [SerializeField] private float _maxRotation = 15f; // Maximum rotation angle in degrees
    [SerializeField] private float _speed = 100f;       // Speed of rotation
    [SerializeField] private float _returnSpeed = 2f;  // Speed at which the board returns to neutral position

    private float _currentXRotation = 0f;
    private float _currentZRotation = 0f;
    private const float _inputThreshold = 0.3f; // Threshold for input normalization

    private void FixedUpdate()
    {
        Vector2 input = _rotateAction.action.ReadValue<Vector2>();

        float xInput = NormalizeInput(input.y);
        float zInput = NormalizeInput(input.x);

        if (xInput != 0 || zInput != 0)
        {
            float xRotation = xInput * _speed * Time.fixedDeltaTime;
            float zRotation = zInput * _speed * Time.fixedDeltaTime;

            _currentXRotation += xRotation;
            _currentZRotation += zRotation;

            _currentXRotation = Mathf.Clamp(_currentXRotation, -_maxRotation, _maxRotation);
            _currentZRotation = Mathf.Clamp(_currentZRotation, -_maxRotation, _maxRotation);
        }
        else
        {
            _currentXRotation = Mathf.Lerp(_currentXRotation, 0f, Time.fixedDeltaTime * _returnSpeed);
            _currentZRotation = Mathf.Lerp(_currentZRotation, 0f, Time.fixedDeltaTime * _returnSpeed);
        }

        transform.localRotation = Quaternion.Euler(_currentXRotation, transform.localRotation.eulerAngles.y, -_currentZRotation);
    }

    private float NormalizeInput(float input)
    {
        if (Mathf.Abs(input) < _inputThreshold)
        {
            return 0f;
        }
        else
        {
            return Mathf.Sign(input);
        }
    }
}
