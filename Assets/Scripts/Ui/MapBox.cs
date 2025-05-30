using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBox : MonoBehaviour, IInterctable
{
    public BuildCardData placeData;
    public InfoUi infoUi;
    public string myCase;

    public string MyInfo()
    {
        string info = "Enter The Stage";

        return info;
    }
    public string MyCase()
    {
        infoUi = UiManager.Instance.mainUi.infoLayout.GetComponent<InfoUi>();
        infoUi.SetSceneCard(placeData);
        return myCase;
    }
}
