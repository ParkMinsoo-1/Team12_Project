using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerController _playerController;
    public Interaction _interaction;
    private void Awake()
    {
        PlayerManager.Instance.Player = this;
        _playerController = GetComponent<PlayerController>();
        _interaction = GetComponent<Interaction>();
    }

}
