using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private ItemDataSO itemData;
    public ItemDataSO ItemData => itemData;
}
