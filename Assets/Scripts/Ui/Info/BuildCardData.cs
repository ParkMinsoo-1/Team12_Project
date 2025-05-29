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
}
