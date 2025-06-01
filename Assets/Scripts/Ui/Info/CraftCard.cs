using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CraftCard : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TextMeshProUGUI[] texts;
    public Image photo;
    public Recipe recipeData;
    public InfoUi infoUi;

    //스크립터블 오브젝트로 건설 가능한 정보를 받아옴
    private bool isMouseOn = false;
    //private Vector2 mouseInfoPos = Vector2.zero;
    //private Vector2 buttonPos = Vector2.zero;

    private void Start()
    {
        texts[0].text = recipeData.CraftName;
        texts[1].text = recipeData.Discription;
        photo.sprite = recipeData.Photo;
    }
    public void OnPointerEnter(PointerEventData eventData)
    //마우스포인터가 콜라이더처럼 자신의 범위안에 들어왔을 때
    //이 범위는 오브젝트 자체 범위인듯함
    {
        //Rect buttonArea = new Rect(button.position, 4f);
        //eventData.currentInputModule
        isMouseOn = true;
        infoUi = FindObjectOfType<InfoUi>();
        infoUi.ShowBuildInfo(true);

    }
    public void OnPointerExit(PointerEventData eventData)
    //마우스포인터가 콜라이더처럼 자신의 범위안에서 나갔을 때
    {
        isMouseOn = false;
        infoUi.ShowBuildInfo(false);
        infoUi = null;

    }

    public void UpgadeBuild()
    {
        BuildableObject buildableObject = FindObjectOfType<BuildableObject>();
        string name = recipeData.CraftName;
        int a = 0;
        switch (name)
        {
            case "Axe":
                a = 0;
                buildableObject.Build(a, this.gameObject);
                infoUi.OnShowCraftPanel();
                UiManager.Instance.mainUi.UpdateInfoUi(null, false);
                GameManager.Instance.select = "Base";
                GameManager.Instance.isStateRunning = false;
                infoUi.ShowBuildInfo(false);
                return;
            case "Work Bench":

                break;
        }
        infoUi.ShowBuildInfo(false);
        Destroy(this.gameObject);
    }
}
