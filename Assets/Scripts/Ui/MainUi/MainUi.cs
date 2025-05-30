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
    public void AddUiItem(ItemDataSO itemData)
    {
        InventoryUi invenUi = inventoryLayout.GetComponent<InventoryUi>();
        invenUi.SettingUiItem(itemData);
    }
    public void UpdateInfoUi(string? info, bool onOff)
    {
        InfoUi infoUi = infoLayout.GetComponent<InfoUi>();
        if (info != null && UiManager.Instance.cardData != null)
        {
            infoUi.SetInfoUi(info);
            infoUi.SetBuildCard(UiManager.Instance.cardData);
        }
        infoUi.objectInfoPanel.SetActive(onOff);
    }
}
