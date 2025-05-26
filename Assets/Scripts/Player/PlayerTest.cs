using UnityEngine;

public class PlayerTest : MonoBehaviour
{
    Rigidbody rigid;
    [SerializeField] float MoveSpeed;
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        PlayerMove();
    }

    private void PlayerMove()
    {
        Vector3 move;
        if(Input.GetKey(KeyCode.W))
        {
            move = transform.position + Vector3.forward * MoveSpeed;
        }
        else if(Input.GetKey(KeyCode.A))
        {
            move = transform.position + Vector3.left * MoveSpeed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            move = transform.position + Vector3.back * MoveSpeed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            move = transform.position + Vector3.right * MoveSpeed;
        }
        else
        {
            move = default(Vector3);
        }

        if (move != default(Vector3))
        {
            rigid.MovePosition(move);
        }       
    }
}
