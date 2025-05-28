using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    #region singleton
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
    #endregion
    #region TestManager
    public Controller controller;
    private Controller Controller => controller;
    public TestInventory inventory;
    private TestInventory Inventory => inventory;
    #endregion
    [SerializeField] private List<ItemDataSO> playerInven = new List<ItemDataSO>();
    



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


    public void PickUp(ItemDataSO itemData)
    {
        // Item data for inventory
        //Controller player = FindObjectOfType<Controller>();
        playerInven.Add(itemData);
        Debug.Log($"인벤토리에 {itemData.itemName} 이 추가되었습니다.");
        

        //Debug.Log($"[�κ��丮] {itemData.itemName}");
    }
    
    
    public bool HasResource(List<ItemDataSO> requiredItems)
    {
        foreach (var requiredItem in requiredItems)
        {
            if (!playerInven.Contains(requiredItem))
                return false;
        }
        return true;
    }

    public void RemoveResource(List<ItemDataSO> usedItems)
    {
        foreach (var usedItem in usedItems)
        {
            playerInven.Remove(usedItem);
        }
    }
}
