using UnityEngine;

public class SpwanItem : MonoBehaviour
{
    [SerializeField] GameObject Item1;

    Transform[] spawnAreaArr;

    private void Start()
    {
        spawnAreaArr = GetComponentsInChildren<Transform>();
        SpawnItem();
    }

    void SpawnItem()
    {
        for(int j = 1; j < spawnAreaArr.Length; j++)
        {
            for (int i = 0; i < 5; i++)
            {
                float x = Random.Range(0, spawnAreaArr[j].localScale.x) / spawnAreaArr[j].localScale.x - 0.5f;
                float z = Random.Range(0, spawnAreaArr[j].localScale.z) / spawnAreaArr[j].localScale.z - 0.5f;

                Vector3 spawnVec = new Vector3(x, 0, z);
                Vector3 spawnScale = new Vector3(1 / spawnAreaArr[j].localScale.x, 1, 1 / spawnAreaArr[j].localScale.z);

                GameObject go = Instantiate(Item1, spawnAreaArr[j]);
                go.transform.localPosition = spawnVec;
                go.transform.localScale = spawnScale;
            }
        }        
    }
}
