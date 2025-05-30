using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUi : MonoBehaviour
{
    public DroppableEquipUi[] equipSlots;
    public Transform uiInventory;
    public GameObject uiItemPrefabs;
    
    private List<DraggableUi> itemList = new List<DraggableUi>();


    //private void InitEquipSlot()
    //{
    
    //}
    public void SettingUiItem(ItemDataSO itemData)
    {
        DraggableUi newItem = uiItemPrefabs.GetComponent<DraggableUi>();
        newItem.itemData = itemData;
        
        foreach (Transform slot in uiInventory)
        {
            if (slot.childCount == 0)
            {
                GameObject go = Instantiate(uiItemPrefabs, slot);
                itemList.Add(go.GetComponent<DraggableUi>());
                break;
            }
        }
        //Instantiate(uiItemPrefabs);
    }

    public void RemoveUIItem(ItemDataSO itemData)
    {
        for (int i = itemList.Count-1; i >= 0; i--)
        {
            if (itemList[i].itemData.id == itemData.id)
            {
                DraggableUi item = itemList[i];
                itemList.RemoveAt(i);
                Destroy(item.gameObject);
                break;
            }
 
        }
    }

}
