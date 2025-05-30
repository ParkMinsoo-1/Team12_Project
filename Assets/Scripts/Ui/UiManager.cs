using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public static UiManager Instance { get; private set; }
    public MainUi mainUi;

    public Player player;
    public PlayerStatus ps;
    public BuildCardData cardData;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject); // �� ��ȯ �� �����ϰ� �ʹٸ� ���
        }
        else
        {
            Destroy(gameObject); // �ߺ� ����
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            ps.Heal(10);
            
        }
    }
}
