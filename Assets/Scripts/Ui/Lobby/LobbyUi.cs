using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyUi : MonoBehaviour
{
    public GameObject[] taps;
    //게임 버튼들을 참조하는 필드
    public GameObject[] layouts;
    public GameObject playerObj;
    public GameObject items;

    public void Awake()
    {
           
    }


    public void OnStartButtonPress()
    {
        playerObj.SetActive(true);
        items.SetActive(true);

        GameObject cam = FindObjectOfType<Camera>().gameObject;
        Camera mainCam = cam.GetComponent<Camera>();

        cam.transform.position = Vector3.zero;
        cam.transform.rotation = Quaternion.Euler(45f, 45f, 0f);

        mainCam.orthographicSize = 20f;



        cam.AddComponent<FollowCamera>();
        FollowCamera cam2 = cam.GetComponent<FollowCamera>();
        cam2.target = FindObjectOfType<Player>().transform;
        cam2.offset = new Vector3(-30f, 45f, -30f);

        CloseLobbyUi();

    //SceneManager.LoadScene("SampleScene");
    }
    public void CloseLobbyUi()
    {
        for (int i = 0; i < layouts.Length; i++)
        {
            layouts[i].gameObject.SetActive(false);
        }
    }
}
