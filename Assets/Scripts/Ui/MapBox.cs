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
        if (infoUi == null)
        {
            infoUi = FindObjectOfType<InfoUi>();
        }
        string info = "Enter The Stage";

        return info;
    }
    public string MyCase()
    {
        infoUi.SetSceneCard(placeData);
        return myCase;
    }
}
