using UnityEngine;

public class TestUIOnOff : MonoBehaviour
{
    [SerializeField] GameObject buildUI;
    [SerializeField] BuildUI buildUIScript;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab)) //테스트용
        {
            if(buildUI.activeSelf == true)
            {
                buildUI.SetActive(false);
            }
            else if(buildUI.activeSelf == false)
            {
                buildUI.SetActive(true);
                buildUIScript.SetBuildUI();
            }
                
        }
    }
}
