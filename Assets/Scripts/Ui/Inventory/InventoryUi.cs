using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUi : MonoBehaviour
{
    public DroppableEquipUi[] equipSlots;
    public Transform uiInventory;
    public GameObject uiItemPrefabs;


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
                Instantiate(uiItemPrefabs, slot);   
                break;
            }
        }


        //Instantiate(uiItemPrefabs);
    }

}
