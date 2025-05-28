
using System.Collections.Generic;
using UnityEngine;

public class BuildableObject1 : MonoBehaviour, IBuildableObject
{
    int Level = 0;    
    Dictionary<string, int>[] UpgradeRequirement = { new Dictionary<string, int>(), new Dictionary<string, int>(), new Dictionary<string, int>() };

    void Start()
    {
        for(int i =0; i < 4; i++)
        {
            UpgradeRequirement[i].Add("Wood", 2*i+1);
            UpgradeRequirement[i].Add("Stone", 2*i+1);
        }        
    }

    public void Build()
    {

        //if(플레이어가 UpgradeRequirement[0]["Wood"] 이상의 나무 && UpgradeRequirement[0]["Stone"] 이상의 돌을 가지고 있다면)
        {
            //나무 개수 -, 돌 개수 - 
            gameObject.SetActive(true);
            Level = 1;
        }
        //else
        {
            //자원이 부족합니다.
        }
        
    }

    public void Upgrade()
    {

        Level++;
    }

    public void Work()
    {
        
    }    
}
