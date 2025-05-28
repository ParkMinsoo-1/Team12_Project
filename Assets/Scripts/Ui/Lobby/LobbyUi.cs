using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyUi : MonoBehaviour
{
    public GameObject[] taps;
    //게임 버튼들을 참조하는 필드


    public void Awake()
    {
           
    }


    public void OnStartButtonPress()
    {
        SceneManager.LoadScene("SampleScene");
    }

}
