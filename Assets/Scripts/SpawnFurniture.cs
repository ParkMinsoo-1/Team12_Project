using System.Collections.Generic;
using UnityEngine;

public class SpawnFurniture : MonoBehaviour
{
    [SerializeField] GameObject Item0;
    [SerializeField] GameObject Item1;
    [SerializeField] GameObject Item2;
    [SerializeField] GameObject Item3;
    List<GameObject> Items = new List<GameObject>();
    Transform[] spawnAreaArr;
    int[] SpawnType;
    Quaternion furnQuaternion;

    void Start()
    {
        spawnAreaArr = GetComponentsInChildren<Transform>();
        Items.Add(Item0);
        Items.Add(Item1);
        Items.Add(Item2);
        Items.Add(Item3);
        SpawnType = new int[spawnAreaArr.Length];
        for (int i = 0; i < transform.childCount; i++)
        {
            SpawnType[i+1] = int.Parse(transform.GetChild(i).name);
        }

        furnQuaternion = Quaternion.identity;
        SpawnFurns();
    }

    void SpawnFurns()
    {
        for (int j = 1; j < spawnAreaArr.Length; j++)
        {
            float x = Random.Range(-0.5f, 0.5f);
            float z = Random.Range(-0.5f, 0.5f);
            int type = SpawnType[j] / 10;
            int iNum = GetType(type);
            int rotation = GetRotation(SpawnType[j] % 10);
            
            Vector3 spawnVec = new Vector3(x, 0, z);

            GameObject go = Instantiate(Items[type], Vector3.zero, furnQuaternion, spawnAreaArr[j]);
            go.transform.GetChild(iNum).gameObject.SetActive(true);
            go.transform.localPosition = spawnVec;
            go.transform.rotation = Quaternion.Euler(new Vector3(0, rotation, 0));
        }
    }

    int GetRotation(int rotation)
    {
        switch (rotation)
        {
            case 1:
                return 270+45;
            case 2:
                return 0 + 45;
            case 3:
                return 90 + 45;
            case 4:
                return 180 + 45;
            default:
                return 0 + 45;
        }
    }

    int GetType(int type)
    {
        int count = Items[type].transform.childCount;
        int iNum = Random.Range(0, count);

        return iNum;
    }
}
