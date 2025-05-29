using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "BuildCard")]
public class BuildCardData : ScriptableObject
{
    [SerializeField] string name;
    public string Name => name;

    [SerializeField] string discription;
    public string Discription => discription;

    [SerializeField] Sprite photo;
    public Sprite Photo => photo;

    [SerializeField] int jsonDataIndex_1;
    public int JsonDataIndex_1 => jsonDataIndex_1;

    [SerializeField] int jsonDataIndex_2;
    public int JsonDataIndex_2 => jsonDataIndex_2;
}
