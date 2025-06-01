using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    void TakePhysicalDamage(int damageAmount);
}

public class Weapon : MonoBehaviour
{
    private ItemDataSO itemData;
    public BoxCollider col;
    public bool isAttack = false;
    public bool isAttackEnd = false;

    public Coroutine attackRoutine;
    
    private void OnTriggerEnter(Collider other)
    {
        if (PlayerManager.Instance.Player._playerController.isAttack)
        {
            if (other.TryGetComponent<IDamageable>(out IDamageable target) && other.CompareTag("Enemy"))
            {
                target.TakePhysicalDamage((int)itemData.atk);
            }
        }
    }

    public void SetWeaponData(ItemDataSO weaponData)
    {
        itemData = weaponData;
    }

    public void InitWeapon()
    {
        col.enabled = true;
    }

}
