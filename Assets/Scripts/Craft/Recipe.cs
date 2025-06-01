using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewRecipe", menuName = "Craft/Recipe")]
public class Recipe : ScriptableObject
{
    [SerializeField] string craftName;
    public string CraftName => craftName;

    [SerializeField] string discription;
    public string Discription => discription;

    [SerializeField] Sprite photo;
    public Sprite Photo => photo;

    [SerializeField] int jsonDataIndex_1;
    public int JsonDataIndex_1 => jsonDataIndex_1;

    [SerializeField] int jsonDataIndex_2;
    public int JsonDataIndex_2 => jsonDataIndex_2;

    public List<ItemDataSO> resources;
    public ItemDataSO result;
}
