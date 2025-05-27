using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerController _playerController;
    
    private void Awake()
    {
        _playerController = GetComponent<PlayerController>();
    }
}
