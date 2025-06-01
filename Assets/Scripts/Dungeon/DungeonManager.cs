using System.Collections.Generic;
using UnityEngine;

public class DungeonManager : MonoBehaviour
{
    //맵코드를 받아서 맵 on/off, 해당 위치로 플레이어 이동
    [SerializeField] GameObject player;
    InfoUi infoUi;
    float mapDistance;
    Vector3 mapStartPosition;

    [SerializeField] List<GameObject> mapList = new List<GameObject>();

    public void EnterDungeon(int mapCode)
    {
        SetMap();
        mapList[mapCode].gameObject.SetActive(true);
    }

    public void EnterDungeon()
    {
        SetMap();
        infoUi = FindAnyObjectByType<InfoUi>();
        mapList[infoUi.nowMapCode].gameObject.SetActive(true);
    }

    public void SetMap()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            mapList.Add(gameObject.transform.GetChild(i).gameObject);
        }
        mapDistance = mapList[1].transform.position.z - mapList[0].transform.position.z;
    }
}
