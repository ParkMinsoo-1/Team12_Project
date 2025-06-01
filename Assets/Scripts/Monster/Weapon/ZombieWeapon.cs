using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieWeapon : MonoBehaviour
{
    public BoxCollider col;
    public NormalZombie zombie;
    public bool isAttack = false;

    public void OnAttack()
    {
        col.enabled = true;
    }
    public void OnAttackEnd()
    {
        isAttack = false;
        col.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isAttack) return;

        isAttack = true;

        if (other.TryGetComponent(out IDamageable target) && other.CompareTag("Player"))
        {
            Debug.Log($"플레이어 피해 입힘 데미지 : {zombie.zombieData.Atk}");
            target.TakePhysicalDamage(zombie.zombieData.Atk);
        }
    }
}
