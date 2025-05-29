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
    //���콺�����Ͱ� �ݶ��̴�ó�� �ڽ��� �����ȿ� ������ ��
    //�� ������ ������Ʈ ��ü �����ε���
    {
        button.color = Color.green;
    }
    public void OnPointerExit(PointerEventData eventData)
    //���콺�����Ͱ� �ݶ��̴�ó�� �ڽ��� �����ȿ��� ������ ��
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
