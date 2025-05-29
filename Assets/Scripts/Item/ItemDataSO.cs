using UnityEngine;

public enum Itemtype
{
    weapon,
    armor,
    tools,
    resources,
    food
}

[CreateAssetMenu(fileName = "NewItem")]
public class ItemDataSO : ScriptableObject
{
    [Header("Base")]
    public int id;
    public string itemName;
    public string description;
    public Sprite icon;
    public Itemtype itemtype;
    //public ToolType toolType;
    public int maxStack;
    public float price;
    public bool equipment = false;

    [Header("Equip")]
    public float atk;
    public float def;

    [Header("Heal")]
    public float healAmount;
    public float duration;

    [Header("Food")]
    public float hunger;
}
