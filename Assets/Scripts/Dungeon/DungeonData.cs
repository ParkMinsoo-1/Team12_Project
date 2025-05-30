using UnityEngine;

[CreateAssetMenu(fileName = "Dungeon Data", menuName = "Scriptable Object/Dungeon Data", order = int.MaxValue)]
public class DungeonData : ScriptableObject
{
    [SerializeField] int dungeonCode;
    [SerializeField] string Name;
    [SerializeField] string description;

}
