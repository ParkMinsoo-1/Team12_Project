using UnityEngine;

public class SpawnFurniture : MonoBehaviour
{
    [SerializeField] GameObject Item1;

    Transform[] spawnAreaArr;
    Quaternion furnQuaternion;

    void Start()
    {
        spawnAreaArr = GetComponentsInChildren<Transform>();
        furnQuaternion = Quaternion.identity;
        SpawnFurns();
    }

    void SpawnFurns()
    {
        for (int j = 1; j < spawnAreaArr.Length; j++)
        {
            float x = Random.Range(0, spawnAreaArr[j].localScale.x) / spawnAreaArr[j].localScale.x - 0.5f;
            float z = Random.Range(0, spawnAreaArr[j].localScale.z) / spawnAreaArr[j].localScale.z - 0.5f;

            Vector3 spawnVec = new Vector3(x, 0, z);
            //Vector3 spawnScale = new Vector3(1 / spawnAreaArr[j].localScale.x, 1, 1 / spawnAreaArr[j].localScale.z);

            GameObject go = Instantiate(Item1, Vector3.zero, furnQuaternion, spawnAreaArr[j]);
            go.transform.localPosition = spawnVec;
            go.transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
        }
    }
}
