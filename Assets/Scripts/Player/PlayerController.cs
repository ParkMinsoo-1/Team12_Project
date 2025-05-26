using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Vector2 movInput;
    
    [Header ("Movement")]
    [SerializeField] private float movSpeed;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
    }
    
    public void MoveInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            movInput = context.ReadValue<Vector2>();
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            movInput = Vector2.zero;
        }
    }

    void Move()
    {
        Vector3 forward = Vector3.forward;
        Vector3 right = Vector3.right;
        
        Vector3 direction = forward*movInput.y + right*movInput.x;
        direction *= movSpeed;
        direction.y = _rigidbody.velocity.y;
        _rigidbody.velocity = direction;
    }
}
