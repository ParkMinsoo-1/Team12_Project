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
        // Item data for inventory
        Controller player = FindObjectOfType<Controller>();
        player.AddItem(itemData);

        Debug.Log($"[인벤토리] {itemData.itemName}");
    }
}
