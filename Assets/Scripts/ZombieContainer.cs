using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ZombieContainer : MonoBehaviour
{
    private static ZombieContainer instance = null;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public static ZombieContainer Instance
    {
        get { if(instance == null)
            {
                return null;
            }
        return instance;
        }
    }

    [SerializeField]  List<GameObject> zombieList = new List<GameObject>();

    public GameObject GetZombie()
    {
        int iNum = Random.Range(0, zombieList.Count);

        return zombieList[iNum];
    }
}
