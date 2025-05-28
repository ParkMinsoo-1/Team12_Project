
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

        //if(�÷��̾ UpgradeRequirement[0]["Wood"] �̻��� ���� && UpgradeRequirement[0]["Stone"] �̻��� ���� ������ �ִٸ�)
        {
            //���� ���� -, �� ���� - 
            gameObject.SetActive(true);
            Level = 1;
        }
        //else
        {
            //�ڿ��� �����մϴ�.
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
