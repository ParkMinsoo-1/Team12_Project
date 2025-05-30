using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildObj : MonoBehaviour, IInterctable
{
    public BuildCardData buildData;

    public string MyInfo()
    {
        string info = "Open Build Tab";
        UiManager.Instance.cardData = buildData;

        return info;
    }
    public string MyCase()
    {
        return "Build";
    }
}
