using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Vector2 movInput;
    public AnimationController _animationController;
    public bool isOpenInven = false;
    public bool isAttack;
    public bool isDead = false;

    [Header ("Movement")]
    [SerializeField] private float movSpeed;

    [SerializeField] private float rotateSpeed;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animationController = GetComponentInChildren<AnimationController>();
    }

    private void FixedUpdate()
    {
        if(isDead) return;

        if (isAttack == false)
        {
            Move();
        }
        //Rotate(); 로테이션 방식 변경
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
    
    // 점프 기능이 필요하다면 구현 할 예정.
    // public void JumpInput(InputAction.CallbackContext context)
    // {
    //     
    // }

    void Move()
    {
        Quaternion angle = Quaternion.Euler(0, 45f, 0);
        
        Vector3 forward = angle * Vector3.forward;
        Vector3 right = angle * Vector3.right;

        Vector3 direction = forward*movInput.y + right*movInput.x;
        _rigidbody.MovePosition(_rigidbody.position + (direction * movSpeed * Time.fixedDeltaTime));
        _animationController.Move(direction);
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
    public void OnOpenInventory(InputAction.CallbackContext context)
    {
        if (isDead) return;

        if (context.performed)
        {
            switch (isOpenInven)
            {
                case false:
                    isOpenInven = true;
                    UiManager.Instance.mainUi.UiTabControl("OpenInven");
                    break;

                case true:
                    isOpenInven = false;
                    UiManager.Instance.mainUi.UiTabControl("CloseInven");
                    break;
            }
        }
    }

    public void OnAttackInput(InputAction.CallbackContext context)
    {
        if (isDead) return;

        if (context.phase == InputActionPhase.Started)
        {
            _animationController.Attack();
            isAttack = true;
        }
    }


    //마우스 위치에 따른 플레이어 방향 전환
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
