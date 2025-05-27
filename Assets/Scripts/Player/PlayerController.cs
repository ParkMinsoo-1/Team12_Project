using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Vector2 movInput;
    public AnimationController animationController;
    
    [Header ("Movement")]
    [SerializeField] private float movSpeed;

    [SerializeField] private float rotateSpeed;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        animationController = GetComponentInChildren<AnimationController>();
    }

    private void FixedUpdate()
    {
        Move();
        //Rotate(); 로테이션함수 변경
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
/// <summary>
/// Interaction 정보에 따른 처리가 필요해보임.
/// Object가 자원인지 제작 도구인지
/// </summary>
/// <param name="context"></param>
    public void InteractInput(InputAction.CallbackContext context)
    {
        
    }
    
    // 점프 기능이 필요하다면 구현 할 예정.
    // public void JumpInput(InputAction.CallbackContext context)
    // {
    //     
    // }
    

    void Move()
    {
        Vector3 forward = Vector3.forward;
        Vector3 right = Vector3.right;
        
        Vector3 direction = forward*movInput.y + right*movInput.x;
        direction *= movSpeed;
        //direction.y = _rigidbody.velocity.y; 점프(?) 추가해야 한다면 활성화 시킴. 점프 추가 시 추가 변수 생성 필요.
        _rigidbody.velocity = direction;
        animationController.Move(direction);
        MoveDirection(direction);
    }

    void MoveDirection(Vector3 direction)
    {
        if (direction.sqrMagnitude > 0.1f)
        {
            direction.y = 0;
            
            Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime*rotateSpeed);
        }
    }

    // void Rotate()
    // {
    //     Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //     Plane plane = new Plane(Vector3.up, transform.position);
    //     float distance;
    //
    //     if (plane.Raycast(ray, out distance))
    //     {
    //         Vector3 point = ray.GetPoint(distance);
    //         Vector3 direction = (point - transform.position).normalized;
    //         direction.y = 0.0f;
    //         
    //         Quaternion rotation = Quaternion.LookRotation(direction);
    //         transform.rotation = rotation;
    //     }
    // }

}
