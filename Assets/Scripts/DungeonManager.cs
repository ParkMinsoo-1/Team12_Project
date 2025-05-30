using System.Collections.Generic;
using UnityEngine;

public class DungeonManager : MonoBehaviour
{
    //���ڵ带 �޾Ƽ� �� on/off, �ش� ��ġ�� �÷��̾� �̵�
    [SerializeField] GameObject player;
    float mapDistance;
    Vector3 mapStartPosition;

    List<GameObject> mapList = new List<GameObject>();

    private void Start()
    {
        for(int i = 0; i < gameObject.transform.childCount; i++)
        {
            mapList.Add(gameObject.transform.GetChild(i).gameObject);
        }
        mapDistance = mapList[1].transform.position.z - mapList[0].transform.position.z;
    }

    public void EnterDungeon(int mapCode)
    {
        mapList[mapCode].gameObject.SetActive(true);
        mapStartPosition.z = mapDistance * mapCode;

        player.transform.position = mapStartPosition;
    }
}
