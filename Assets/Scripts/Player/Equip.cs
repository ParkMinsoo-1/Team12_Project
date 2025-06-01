using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equip : MonoBehaviour
{
    [SerializeField] private ItemDataSO defaultWeaponPrefab;  // 기본 무기 프리팹
    private GameObject weaponInstance;  // 현재 장착된 무기 인스턴스
    
    Transform FindDeepChild(Transform parent, string name)
    {
        foreach (Transform child in parent)
        {
            if (child.name == name)
                return child;

            Transform result = FindDeepChild(child, name);
            if (result != null)
                return result;
        }
        return null;
    }
    void Start()
    {
        // 처음 시작할 때 기본 무기 장착, 만약 기본 장착 무기에 무기가 아닌 것이 들어가면 파괴.
        if (defaultWeaponPrefab != null)
        {
            if (defaultWeaponPrefab.itemtype != Itemtype.weapon)
            {
                defaultWeaponPrefab = null;
            }
            else
            {
                EquipWeapon(defaultWeaponPrefab);
            }
        }
    }

    // 무기 장착 함수 (외부에서 선택 무기 프리팹을 받아옴)
    public void EquipWeapon(ItemDataSO weaponPrefab)
    {
        if (weaponPrefab.itemtype != Itemtype.weapon)
        {
            Debug.Log("장찰 할 수 없습니다.");
        }
        
        //손 위치 찾기
        Transform handTransform = FindDeepChild(transform, "jointItemR");
        if (handTransform == null)
        {
            Debug.LogWarning("손을 찾을 수 없습니다.");
            return;
        }

        // 이미 장착 중인 무기가 있다면 제거
        if (weaponInstance != null)
            Destroy(weaponInstance);

        // 새로운 무기 생성 & 장착
        weaponInstance = Instantiate(weaponPrefab.itemPrefab, handTransform);
        
        Weapon weaponScript = weaponInstance.GetComponent<Weapon>();
        if (weaponScript != null)
        {
            weaponScript.SetWeaponData(weaponPrefab);
            weaponScript.InitWeapon();
            PlayerManager.Instance.Player._playerController._animationController.weapon = weaponScript;
        }
    }
    
    public void UnEquipWeapon()
    {
        if (weaponInstance != null)
        {
            PlayerManager.Instance.Player._playerController._animationController.weapon = null;
            Destroy(weaponInstance);
            weaponInstance = null;
        }
    }
}

