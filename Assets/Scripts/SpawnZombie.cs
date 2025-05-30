using System.Collections.Generic;
using UnityEngine;

public class SpawnZombie : MonoBehaviour
{
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
            zombie = ZombieContainer.Instance.GetZombie();
            Instantiate(zombie, zombieSpawners[i].transform.position, zombieRotation);
        }
    }
}
