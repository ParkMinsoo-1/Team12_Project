using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform weaponPrefab;  // 붙일 무기 프리팹
    private Transform weaponInstance;  // 생성된 무기 인스턴스
    
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
        Transform handTransform = FindDeepChild(transform, "jointItemR");
        if (handTransform != null)
        {
            Instantiate(weaponPrefab, handTransform);
        }
    }

}
