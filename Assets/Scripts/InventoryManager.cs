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
}
