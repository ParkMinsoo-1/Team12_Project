using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class MainUi : MonoBehaviour
{
    public GameObject mainLayout;
    public GameObject infoLayout;
    public GameObject inventoryLayout;


    public void UiTabControl(string order)
    {
        switch (order)
        {
            case "OpenMain":
                mainLayout.SetActive(true);
                break;
            case "OpenInven":
                mainLayout.SetActive(false);
                inventoryLayout.SetActive(true);
                break;
            case "CloseInven":
                mainLayout.SetActive(true);
                inventoryLayout.SetActive(false);
                break;
            case "CloseAll":
                mainLayout.SetActive(false);
                infoLayout.SetActive(false);
                inventoryLayout.SetActive(false);
                break;
        }
    }
    public void AddUiItem(ItemDataSO itemData) //  InventoryUI 상에 아이템 넣기
    {
        InventoryUi invenUi = inventoryLayout.GetComponent<InventoryUi>();
        invenUi.SettingUiItem(itemData);
    }

    public void RemoveUIItem(ItemDataSO itemData)
    {
        InventoryUi invenUi = inventoryLayout.GetComponent<InventoryUi>();
        invenUi.RemoveUIItem(itemData);
    }
    
    public void UpdateInfoUi(string? info, bool onOff)
    {
        InfoUi infoUi = infoLayout.GetComponent<InfoUi>();
        if (info != null)
        {
            infoUi.SetInfoUi(info);
            if (UiManager.Instance.cardData != null)
            {
                infoUi.SetBuildCard(UiManager.Instance.cardData);
            }
            else if(UiManager.Instance.recipeData != null)
            {                
                infoUi.SetCraftCard(UiManager.Instance.recipeData);
            }
        }
        infoUi.objectInfoPanel.SetActive(onOff);
    }
}
