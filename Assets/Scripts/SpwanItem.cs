using UnityEngine;

public class SpwanItem : MonoBehaviour
{
    [SerializeField] GameObject Item1;
    [SerializeField] GameObject[] resourcesItem;    
    [SerializeField] GameObject[] foodItem;
    [SerializeField] GameObject[] toolItem;

    Transform[] spawnAreaArr;

    private void Start()
    {
        spawnAreaArr = GetComponentsInChildren<Transform>();
        SpawnItem();
    }

    void SpawnItem()
    {
        for (int j = 1; j < spawnAreaArr.Length; j++)
        {
            int iNum = Random.Range(3, 5);
            for (int i = 0; i < iNum; i++)
            {
                int itemCount = resourcesItem.Length;
                iNum = Random.Range(0, itemCount);
                float x = Random.Range(-0.5f, 0.5f);
                float z = Random.Range(-0.5f, 0.5f);

                Vector3 spawnVec = new Vector3(x, 0, z);
                Vector3 spawnScale = new Vector3(4 / spawnAreaArr[j].localScale.x, 4, 4 / spawnAreaArr[j].localScale.z);

                GameObject go = Instantiate(resourcesItem[iNum], spawnAreaArr[j]);
                go.transform.localPosition = spawnVec;
                go.transform.localScale = spawnScale;
            }

            iNum = Random.Range(1, 2);
            for (int i = 0; i < iNum; i++)
            {
                int itemCount = foodItem.Length;
                iNum = Random.Range(0, itemCount);
                float x = Random.Range(-0.5f, 0.5f);
                float z = Random.Range(-0.5f, 0.5f);

                Vector3 spawnVec = new Vector3(x, 0, z);
                Vector3 spawnScale = new Vector3(6 / spawnAreaArr[j].localScale.x, 6, 6 / spawnAreaArr[j].localScale.z);

                GameObject go = Instantiate(foodItem[iNum], spawnAreaArr[j]);
                go.transform.localPosition = spawnVec;
                go.transform.localScale = spawnScale;
            }

            iNum = Random.Range(1, 101);
            if(iNum > 90)
            {
                int itemCount = toolItem.Length;
                iNum = Random.Range(0, itemCount);
                float x = Random.Range(-0.5f, 0.5f);
                float z = Random.Range(-0.5f, 0.5f);

                Vector3 spawnVec = new Vector3(x, 0, z);
                Vector3 spawnScale = new Vector3(6 / spawnAreaArr[j].localScale.x, 6, 6 / spawnAreaArr[j].localScale.z);

                GameObject go = Instantiate(toolItem[iNum], spawnAreaArr[j]);
                go.transform.localPosition = spawnVec;
                go.transform.localScale = spawnScale;
            }
        }
    }
}
