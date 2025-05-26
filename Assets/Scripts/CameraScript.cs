using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] GameObject player;



    void LateUpdate()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;
        RaycastHit[] hits = Physics.RaycastAll(transform.position, direction, Mathf.Infinity, 1 << 6);

        if (hits == null) return;

        List<TransparentObject> obj = new List<TransparentObject>();

        for (int i = 0; i < hits.Length; i++)
        {
            obj.Add(hits[i].transform.GetComponent<TransparentObject>());
            obj[i]?.BecomeTransparent();
        }
    }
}
