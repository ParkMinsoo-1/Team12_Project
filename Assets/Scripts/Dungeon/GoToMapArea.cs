using UnityEngine;

public class GoToMapArea : MonoBehaviour, IInterctable
{
    public BuildCardData placeData;
    public InfoUi infoUi;
    public string myCase;

    public string MyInfo()
    {
        return "Open Map";
    }
    public string MyCase()
    {
        infoUi = UiManager.Instance.mainUi.infoLayout.GetComponent<InfoUi>();
        infoUi.SetSceneCard(placeData);
        return "SceneMap";
    }   
}
