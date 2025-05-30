using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    void TakePhysicalDamage(float damageAmount);
}

public class Weapon : MonoBehaviour
{
    private ItemDataSO itemData;
    
    private void OnTriggerEnter(Collider other)
    {
        // 인터페이스를 찾는다
        // 예시로 만들어 놓음.
        // IDamageable damageable = other.GetComponent<IDamageable>();
        //
        //
        // 무기의 타입 검출, 무기일 경우, 무기가 가지고 있는 데미지 주기.
        //  if (damageable != null)
        //  {
        //      damageable.TakePhysicalDamage(itemData.atk);
        //  }
    }

    public void SetWeaponData(ItemDataSO weaponData)
    {
        itemData = weaponData;
    }

}
