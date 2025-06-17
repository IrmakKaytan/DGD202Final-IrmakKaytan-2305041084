using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMover : MonoBehaviour
{
    private Rigidbody _rigidbody;
    
    [Header("Movement Parameters")]
    [field: SerializeField] public float MoveSpeed { get; private set; }
    [SerializeField] private float _turnSpeed = 180f; // Increased default turn speed
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Move(Vector2 direction)
    {
        float moveX = direction.x;
        float moveZ = direction.y;

        // Calculate rotation based on input and turn speed
        float rotationAmount = moveX * _turnSpeed * Time.deltaTime;
        Quaternion deltaRotation = Quaternion.Euler(0f, rotationAmount, 0f);
        _rigidbody.MoveRotation(_rigidbody.rotation * deltaRotation);
        
        // Move forward/backward
        _rigidbody.linearVelocity = transform.forward * (moveZ * MoveSpeed);
    }
}
