using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private static PlayerManager _instance;

    public static PlayerManager Instance
    {
        get
        {
            return _instance;
        }
    }
    //private Player _player;

    public Player Player;

    public Vector3 playerPos;

    public string playerSelect;


    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (_instance != this)
            {
                Destroy(gameObject);
            }
        }
    }
    private void FixedUpdate()
    {
        playerPos = Player.transform.position;
    }

    public float CheckDistanceOfPlayer(Vector3 zombiePos)
    {
        float distance = Vector3.Distance(playerPos, zombiePos);
        return distance;
    }
}

