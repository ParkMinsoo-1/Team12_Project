using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerStatus : MonoBehaviour
{
    public StatusManager statusManager;
    
    Status health { get { return statusManager.health;}}
    Status hunger { get { return statusManager.hunger;}}
    Status stamina { get { return statusManager.stamina;}}

}
