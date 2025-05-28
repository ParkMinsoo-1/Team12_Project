using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{

    public static UiManager Instance { get; private set; }
    public MainUi mainUi;

    public Player player;
    public PlayerStatus ps; 

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject); // 씬 전환 시 유지하고 싶다면 사용
        }
        else
        {
            Destroy(gameObject); // 중복 방지
        }
        mainUi = FindObjectOfType<MainUi>();
    }




    private void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            ps.Heal(10);
            
        }
    }
}
