using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPlayer : MonoBehaviour
{

    [SerializeField] Rigidbody rigid;
    float hAxis;
    float vAxis;
    Vector3 moveDirection;

    private void Update()
    {
        Move();
        
    }

    public void Move()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector3(hAxis, 0, vAxis).normalized;

        transform.position += moveDirection * 5f * Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("플레이어 맵인식");
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("플레이어 맵인식해제");
    }
    

}
