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
            case "OpenInfo":
                infoLayout.SetActive(true);
                break;
            case "OpenInven":
                inventoryLayout.SetActive(true);
                break;

            case "CloseInfo":
                infoLayout.SetActive(false);
                break;
            case "CloseInven":
                inventoryLayout.SetActive(false);
                break;
            case "CloseAll":
                mainLayout.SetActive(false);
                infoLayout.SetActive(false);
                inventoryLayout.SetActive(false);
                break;
        }
    }
    public void AddUiItem(ItemDataSO itemData)
    {
        InventoryUi invenUi = inventoryLayout.GetComponent<InventoryUi>();
        invenUi.SettingUiItem(itemData);
    }
}
