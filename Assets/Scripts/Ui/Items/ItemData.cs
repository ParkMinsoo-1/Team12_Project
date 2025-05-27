using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItem")]
public class ItemData : ScriptableObject
{
    public int id;
    public string itemName;
    public string description;
    public Sprite icon;
    public string itemType;
    public int maxStack;
    public float price;
    public bool equipment = false;

    public float atk;
    public float def;

    public float healAmount;
    public float duration;

}
