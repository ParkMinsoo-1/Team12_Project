using UnityEngine;

public enum ToolType
{
    None,
    Axe,
    Pickaxe,
    Knife
}
[CreateAssetMenu(fileName = "NewHarvestable")]
public class HarvestableObjectSO : ScriptableObject
{
    [Header("Base")]
    public int maxHp;
    public ToolType requiredTool;
    public ItemDataSO dropItem;
    public int dropCount;
}
