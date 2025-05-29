using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewRecipe", menuName = "Craft/Recipe")]
public class Recipe : ScriptableObject
{
    public List<ItemDataSO> resources;
    public ItemDataSO result;
}
