using System.Collections.Generic;
using System.Linq;
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
    [SerializeField] private List<ItemDataSO> playerInven = new List<ItemDataSO>();
    #endregion
    



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
        playerInven.Add(itemData);
        UiManager.Instance.mainUi.AddUiItem(itemData);
        Debug.Log($"인벤토리에 {itemData.itemName} 이 추가되었습니다.");
        
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

    public bool SpendResource(string[] resourceName, int[] resourceCount)
    {
        int length = resourceName.Length;
        int[] resourcePlayerHaveCnt = new int[length];
        bool isResourceEnough = true;

        for (int i = 0; i < length; i++)
        {
            resourcePlayerHaveCnt[i] = playerInven.Where(x => x.itemName == resourceName[i]).Count();
            if (resourcePlayerHaveCnt[i] >= resourceCount[i] == false)
            {
                isResourceEnough = true;
            }
        }

        if (isResourceEnough == true)
        {
            //for (int i = 0; i < length; i++)
            //{
            //    playerInven.Remove(playerInven.Where(x => x.itemName == resourceName[i]).Last());
            //}
            return true;
        }
        else
        {
            return false;
        }
    }
}
