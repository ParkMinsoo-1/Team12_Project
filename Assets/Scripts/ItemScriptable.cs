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
public class ItemScriptable : ScriptableObject
{
    public int id;
    public string itemName;
    public string description;
    public Sprite icon;
    public Itemtype itemtype;
    public int maxStack;
    public float price;
    public bool equipment = false;

    public float atk;
    public float def;

    public float healAmount;
    public float duration;
}
