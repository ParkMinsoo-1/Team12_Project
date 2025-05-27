using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private ItemScriptable itemData;
    public ItemScriptable ItemData => itemData;

    private void Update()
    {

    }
}
