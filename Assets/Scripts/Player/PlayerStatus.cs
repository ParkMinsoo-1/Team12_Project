using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerStatus : MonoBehaviour
{
    public StatusManager statusManager;
    
    Status health { get { return statusManager.health;}}
    Status hunger { get { return statusManager.hunger;}}
    Status stamina { get { return statusManager.stamina;}}

    public void update()
    {
        hunger.Subtract(hunger.passiveValue);
        stamina.Subtract(stamina.passiveValue);
    }

    public void Heal(int value)
    {
        health.Add(value);
    }

    public void Eat(int value)
    {
        hunger.Add(value);
    }

    public void Death()
    {
        //플레이어 죽음.
    }

}
