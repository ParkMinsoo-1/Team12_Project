using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Vector2 movInput;
    public AnimationController animationController;
    
    [Header ("Movement")]
    [SerializeField] private float movSpeed;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        animationController = GetComponentInChildren<AnimationController>();
    }

    private void FixedUpdate()
    {
        Move();
        Rotate();
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

    public void InteractInput(InputAction.CallbackContext context)
    {
        
    }

    public void JumpInput(InputAction.CallbackContext context)
    {
        
    }
    

    void Move()
    {
        Vector3 forward = transform.forward;
        Vector3 right = transform.right;
        
        Vector3 direction = forward*movInput.y + right*movInput.x;
        direction *= movSpeed;
        direction.y = _rigidbody.velocity.y; //점프(?)
        _rigidbody.velocity = direction;
        animationController.Move(direction);
    }

    void Rotate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.up, transform.position);
        float distance;

        if (plane.Raycast(ray, out distance))
        {
            Vector3 point = ray.GetPoint(distance);
            Vector3 direction = (point - transform.position).normalized;
            direction.y = 0.0f;
            
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = rotation;
        }
    }
}
