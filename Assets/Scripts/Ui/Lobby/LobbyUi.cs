using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyUi : MonoBehaviour
{
    public GameObject[] taps;
    //���� ��ư���� �����ϴ� �ʵ�


    public void Awake()
    {
           
    }


    public void OnStartButtonPress()
    {
        SceneManager.LoadScene("SampleScene");
    }

}
