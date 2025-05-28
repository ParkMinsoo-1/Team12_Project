using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
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

    //public void SpendResource(string name1, string name2, int lv, Dictionary<string, int>[] UpgradeRequirement)
    //{
    //    int woodCount = playerInven.Where(x => x.itemName == name1).Count();
    //    int stoneCount = playerInven.Where(x => x.itemName == name2).Count();

    //    if (woodCount >= UpgradeRequirement[lv][name1] && stoneCount >= UpgradeRequirement[lv][name2])
    //    {
    //        playerInven.Remove(playerInven.Where(x => x.itemName == "Wood").Last());
    //        playerInven.Remove(playerInven.Where(x => x.itemName == "Stone").Last());
    //    }
    //    else
    //    {
    //        Debug.Log("자원부족");
    //    }
    //}

    public void SpendResource(string[] resourceName, int[] resourceCount)
    {
        int length = resourceName.Length;
        int[] resourcePlayerHaveCnt = new int[length];
        bool isResourceEnough = true;

        for (int i = 0; i < length; i++)
        {
            resourcePlayerHaveCnt[i] = playerInven.Where(x => x.itemName == resourceName[i]).Count();
            if (resourcePlayerHaveCnt[i] >= resourceCount[i] == false)
            {
                isResourceEnough = false;
            }
        }

        if (isResourceEnough == true)
        {
            for (int i = 0; i < length; i++)
            {
                playerInven.Remove(playerInven.Where(x => x.itemName == resourceName[i]).Last());
            }
        }
        else
        {
            Debug.Log("자원부족");
        }
    }
}
