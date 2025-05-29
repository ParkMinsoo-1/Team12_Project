using UnityEngine;

//public enum ToolType
//{
//    None,
//    Axe,
//    Pickaxe,
//    Knife
//}
public enum HarvestName
{
    Tree,
    Rock
}
[CreateAssetMenu(fileName = "NewHarvestable")]
public class HarvestableObjectSO : ScriptableObject
{
    [Header("Base")]
    public int maxHp;
    public HarvestName harvestName;
    //public ToolType requiredTool;
    public ItemDataSO dropItem;
    public int dropCount;
}
