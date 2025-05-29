using UnityEngine;

enum Builderable
{
    Builderable1 = 0,
    Builderable2,
    Builderable3,
    Tent
}
public class BuildableObject : MonoBehaviour, IBuildableObject
{
    [SerializeField] ReadBuildData ReadBuildData;
    [SerializeField] BuildUI buildUI;
    public BuildableObjectsData[][] resourceData;
    public int[] level { get; private set; } = new int[] { 0, 0, 0,0 };

    void Start()
    {
        resourceData = ReadBuildData.GetReadData(); // resourceData[오브젝트타입][레벨]
    }

    public void Build(int type, GameObject buildObject)
    {        
        bool isNoramlOperation = InventoryManager.Instance.SpendResource(resourceData[type][level[type]].ResourcesName, resourceData[type][level[type]].ResourcesCount);

        if(isNoramlOperation == true)
        {
            buildObject.SetActive(true);
            if (level[type] < 3)
            level[type]++;
            buildUI.SetBuildUI();
        }
        else
        {
            Debug.Log("자원이 부족합니다."); // 추후 UI로 띄우도록 수정
        }
    }

    //public void Upgrade(int type)
    //{
    //    if(level[type] == 4)
    //    {
    //        //만랩
    //        return;
    //    }

    //    bool isNoramlOperation = InventoryManager.Instance.SpendResource(resourceData[type][level[type]].ResourcesName, resourceData[type][level[type]].ResourcesCount);

    //    if (isNoramlOperation == true)
    //    {
    //        level[type]++;
    //    }
    //    else
    //    {
    //        Debug.Log("자원이 부족합니다."); // 추후 UI로 띄우도록 수정
    //    }
    //}

    public void Work()
    {
        
    }
}
