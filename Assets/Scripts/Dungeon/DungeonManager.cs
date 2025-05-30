using System.Collections.Generic;
using UnityEngine;

public class DungeonManager : MonoBehaviour
{
    //맵코드를 받아서 맵 on/off, 해당 위치로 플레이어 이동
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

        EnterDungeon(1); // 테스트용
    }

    public void EnterDungeon(int mapCode)
    {
        mapList[mapCode].gameObject.SetActive(true);
        mapStartPosition.z = mapDistance * mapCode;

        player.transform.position = mapStartPosition;
    }
}
