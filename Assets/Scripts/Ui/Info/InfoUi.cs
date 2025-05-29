using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

interface IInterctable
{
    string MyInfo();
}

public class InfoUi : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TMP_Text infoText;
    public Image button;
    public Action changeInfoUi;
    public GameObject buildCard;

    public GameObject buildPanel;
    public GameObject objectInfoPanel;
    public GameObject buildInfo;

    public bool isBuilding = false;
    

    public void SetInfoUi(string info)
    {
        infoText.text = $"{info}";
    }
    public void OnPointerEnter(PointerEventData eventData)
    //마우스포인터가 콜라이더처럼 자신의 범위안에 들어왔을 때
    //이 범위는 오브젝트 자체 범위인듯함
    {
        button.color = Color.green;
    }
    public void OnPointerExit(PointerEventData eventData)
    //마우스포인터가 콜라이더처럼 자신의 범위안에서 나갔을 때
    {
        button.color = Color.red;
    }

    public void OnShowBuildPanel()
    {
        if (!isBuilding)
        {
            isBuilding = true;
            buildPanel.SetActive(true);
            objectInfoPanel.SetActive(false);
            return;
        }
        isBuilding = false;
        buildPanel.SetActive(false);
        objectInfoPanel.SetActive(true);

    }
    public void ShowBuildInfo(bool onOff)
    {
        TMP_Text buildInfoText = buildInfo.GetComponentInChildren<TMP_Text>();
        buildInfoText.text = "wow";
        buildInfo.SetActive(onOff);
    }
    public void UpdateBuildInfoPos(Vector2 mousePos)
    {
        buildInfo.transform.position = mousePos;
    }

}
