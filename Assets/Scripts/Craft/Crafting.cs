using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crafting : MonoBehaviour
{
    public InventoryManager playerInventory;

    public bool Craft(Recipe recipe)
    {
        if (playerInventory == null)
        {
            playerInventory = InventoryManager.Instance;
            
        }
        
        if (playerInventory.HasResource(recipe.resources))
        {
            playerInventory.RemoveResource(recipe.resources);
            playerInventory.PickUp(recipe.result);
            Debug.Log(recipe.result.itemName + "을(를) 제작했습니다!");
            return true;
        }
        else
        {
            Debug.Log("재료가 부족합니다!");
            return false;
        }
    }
}