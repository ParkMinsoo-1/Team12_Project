using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class InventoryManager : MonoBehaviour
{
    private static InventoryManager instance;
    public static InventoryManager Instance
    {
        get 
        { 
            if (instance == null)
            {
                GameObject go = new GameObject("InventoryManager");
                instance = go.AddComponent<InventoryManager>();
                DontDestroyOnLoad(go);
            }
            return instance;
        }
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
                return;
            }
        }
    }

    public void PickUp(ItemScriptable itemData)
    {
        // 인벤토리에 보내줄 정보
        Controller player = FindObjectOfType<Controller>();
        player.AddItem(itemData);

        Debug.Log($"[인벤토리] {itemData.itemName}");
    }
}
