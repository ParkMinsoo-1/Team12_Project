
using System.Collections.Generic;
using UnityEngine;

public class BuildableObject : MonoBehaviour, IBuildableObject
{
    [SerializeField] ReadBuildData ReadBuildData;
    BuildableObjectsData[][] resourceData;
    int level = 0;    
    //Dictionary<string, int>[] UpgradeRequirement = { new Dictionary<string, int>(), new Dictionary<string, int>(), new Dictionary<string, int>(), new Dictionary<string, int>() };
    //string key1 = "Wood";
    //string key2 = "Stone";
    void Start()
    {
        resourceData = ReadBuildData.GetReadData(); //[오브젝트번호][레벨]        
    }

    public void Build()
    {
        //InventoryManager.Instance.SpendResource(key1, key2, level, UpgradeRequirement);
        Debug.Log(resourceData[0][0].ResourcesName[0]);
        InventoryManager.Instance.SpendResource(resourceData[0][level].ResourcesName, resourceData[0][level].ResourcesCount); //오브젝트번호 받아오는거 수정
        gameObject.SetActive(false);
        level++;
    }

    public void Upgrade()
    {
        if(level == 4)
        {
            //만랩
            return;
        }

        //InventoryManager.Instance.SpendResource("Wood", "Stone", level, UpgradeRequirement);
        InventoryManager.Instance.SpendResource(resourceData[0][level].ResourcesName, resourceData[0][level].ResourcesCount); //오브젝트번호 받아오는거 수정

        level++;
    }

    public void Work()
    {
        
    }
}
