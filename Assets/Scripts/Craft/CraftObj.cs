using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftObj : MonoBehaviour, IInterctable
{
    public BuildCardData CraftData;
    CraftStation craftStation;

    void Start()
    {
        craftStation = GetComponent<CraftStation>();
    }

    public string MyInfo()
    {
        string info = "Open Craft Tab";
        UiManager.Instance.recipeData = craftStation.recipes;

        return info;
    }
    public string MyCase()
    {
        return "Craft";
    }
}
