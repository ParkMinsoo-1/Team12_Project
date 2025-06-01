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
    string MyCase();
}

public class InfoUi : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TMP_Text infoText;
    public Image button;
    public Button realButton;
    public Action changeInfoUi;
    public GameObject buildCard;

    public GameObject buildPanel;
    public Transform buildTab;

    public GameObject objectInfoPanel;
    public GameObject buildInfo;

    public GameObject SceneChangePanel;
    public TMP_Text sceneNameText;
    public TMP_Text sceneDiscriptionText;
    public Image sceneIcon;

    public bool isBuilding = false;

    public bool isSceneSelect = false;

    [SerializeField] ReadBuildData ReadBuildData;
    public BuildableObjectsData[][] resourceData;
    public int index_1 = 0;
    public int index_2 = 0;
    public int nowMapCode = 0;
    public Dictionary<string,GameObject> cards = new Dictionary<string,GameObject>();

    private void Awake()
    {
        resourceData = ReadBuildData.GetReadData();
    }
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
    public void ChangeButtonFunc(string choice)
    {
        //int count = realButton.onClick.GetPersistentEventCount();
        //if (count > 0)
        //{
        //    return;
        //}
        realButton.onClick.RemoveAllListeners();

        switch (choice)
        {
            case "Build":
                realButton.onClick.AddListener(OnShowBuildPanel);
                break;

            case "SceneMap":
                GameManager.Instance.select = "Map";
                realButton.onClick.AddListener(OnShowScenePanel);
                break ;
            case "SceneBase":
                GameManager.Instance.select = "Base";
                realButton.onClick.AddListener(OnShowScenePanel);
                break;
            case "SceneStage":
                GameManager.Instance.select = "Stage";
                realButton.onClick.AddListener(OnShowScenePanel);
                break;
        }
    }
    public void OnShowScenePanel()
    {
        if (!isSceneSelect)
        {
            isSceneSelect = true;
            SceneChangePanel.SetActive(true);
            objectInfoPanel.SetActive(false);
            return;
        }
        isSceneSelect = false;
        SceneChangePanel.SetActive(false);
        objectInfoPanel.SetActive(true);
        UiManager.Instance.mainUi.UpdateInfoUi(null, false);
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
        if (buildTab.childCount > 0)
        {
            for (int i = buildTab.childCount - 1; i >= 0; i--)
            {
                Destroy(buildTab.GetChild(i).gameObject);
            }
        }
    }
    public void ShowBuildInfo(bool onOff)
    {
        if (!onOff)
        {
            buildInfo.SetActive(onOff);
            return;
        }

        string[] result = new string[4];
        int[] result_Int = new int[2];
        TMP_Text buildInfoText = buildInfo.GetComponentInChildren<TMP_Text>();
        for (int i = 0; i < 2; i++)
        {

            result[i] = resourceData[index_1][index_2].ResourcesName[i];

            for (int j = 0; j < 2; j++)
            {
                result_Int[j] = resourceData[index_1][index_2].ResourcesCount[j];
                result[2 + j] = $"{result_Int[j]}";
            }
        }

        buildInfoText.text = $"{result[0]} / {result[1]}\n" +
                             $"{result[2]} / {result[3]}";

        buildInfo.SetActive(onOff);
    }
    public void UpdateBuildInfoPos(Vector2 mousePos)
    {
        buildInfo.transform.position = mousePos;
    }
    public void SetBuildCard(BuildCardData data)
    {

        index_1 = data.JsonDataIndex_1;
        index_2 = data.JsonDataIndex_2;
        BuildCard card = buildCard.GetComponent<BuildCard>();
        card.buildData = data;

        Instantiate(buildCard, buildTab);

        /*        foreach (Transform buildSlot in buildTab)
                {
                    if (buildSlot.childCount >= 1)
                    {
                        GameObject theCard = GetComponentInChildren<GameObject>();
                        cards.Add(data.Name, theCard);
                        break;
                    }
                }*/

    }
    public void SetSceneCard(BuildCardData data)
    {
        sceneNameText.text = data.Name;
        sceneDiscriptionText.text = data.Discription;
        sceneIcon.sprite = data.Photo;
        nowMapCode = data.MapCode;
    }
    //public void CheckTheCard(BuildCardData data)
    //{
    //    BuildableObject buildableObject = FindObjectOfType<BuildableObject>();
    //    string name = buildData.Name;
    //    int a = 0;
    //    switch (name)
    //    {
    //        case "Sweet Home":
    //            a = 3;
    //            buildableObject.Build(a);
    //            break;
    //    }
    //    Destroy(this.gameObject);
    //}
}
