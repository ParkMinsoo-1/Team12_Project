using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerStatus : MonoBehaviour, IDamageable
{
    public StatusManager statusManager;
    
    Status health { get { return statusManager.health;}}
    Status hunger { get { return statusManager.hunger;}}
    Status stamina { get { return statusManager.stamina;}}

    public void update()
    {
        hunger.StatChange(hunger.passiveValue, "Subtract");
        stamina.StatChange(stamina.passiveValue, "Subtract");
    }

    public void Heal(int value)
    {
        health.StatChange(value, "Add");
    }

    public void Eat(int value)
    {
        hunger.StatChange(value, "Add");
    }
    public void TakePhysicalDamage(int damageAmount)
    {
        health.StatChange(damageAmount, "Subtract");
    }



    public void Death()
    {
        //플레이어 죽음.
    }

}
