using System.Collections.Generic;
using UnityEngine;

public class SpawnZombie : MonoBehaviour
{
    [SerializeField] List<GameObject> zombieList = new List<GameObject>();
    List<GameObject> zombieSpawners = new List<GameObject>();
    Quaternion zombieRotation = Quaternion.identity;
    void Start()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            zombieSpawners.Add(gameObject.transform.GetChild(i).gameObject);
        }

        ZombieIsReady();
    }

    void ZombieIsReady()
    {
        GameObject zombie;

        for (int i = 0; i < zombieSpawners.Count; i++)
        {
            zombie = GetRandomZombie();
            Instantiate(zombie, zombieSpawners[i].transform.position, zombieRotation);
        }
        
    }

    GameObject GetRandomZombie()
    {
        int iNum = Random.Range(0, zombieList.Count);
        return zombieList[iNum];
    }
}
