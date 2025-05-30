using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] GameObject player;
    RaycastHit[] beforeHits = null;

    void LateUpdate()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;
        RaycastHit[] hits = Physics.RaycastAll(transform.position, direction, Mathf.Infinity, 1 << 7);        

        if (hits == null) return;

        List<TransparentObject> obj = new List<TransparentObject>();
        TransparentObject[] objs;

        if (beforeHits != null)                 //beforehit안에 있지만 hit에는 없는 오브젝트 투명화 해제
        {
            for (int i = 0; i < beforeHits.Length; i++)
            {
                if (hits.Contains(beforeHits[i]) == false)
                {
                    objs = beforeHits[i].transform.GetComponentsInChildren<TransparentObject>();
                    foreach (TransparentObject obj2 in objs)
                    {
                        obj2?.NoTransparent();
                    }
                }
            }
        }

        for (int i = 0; i < hits.Length; i++)   //hit안의 오브젝트 투명화
        {
            objs = hits[i].transform.GetComponentsInChildren<TransparentObject>();
            foreach (TransparentObject obj2 in objs)
            {
                obj2?.BecomeTransparent();
                
            }
        }       
        
        beforeHits = hits;
    }
}
