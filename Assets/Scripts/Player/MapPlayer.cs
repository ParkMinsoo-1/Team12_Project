using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class MapPlayer : MonoBehaviour
{

    [SerializeField] Rigidbody rigid;
    float hAxis;
    float vAxis;
    Vector3 moveDirection;
    public InfoUi infoUi;

    private void Update()
    {
        Move();
        
    }

    public void Move()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector3(hAxis, 0, vAxis).normalized;

        transform.position += moveDirection * 5f * Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IInterctable target))
        {
            infoUi = UiManager.Instance.mainUi.infoLayout.GetComponent<InfoUi>();

            infoUi.ChangeButtonFunc(target.MyCase());
            UiManager.Instance.mainUi.UpdateInfoUi(target.MyInfo(), true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("플레이어 맵인식해제");
        if (UiManager.Instance.cardData != null)
        {
            UiManager.Instance.cardData = null;
        }
        UiManager.Instance.mainUi.UpdateInfoUi(null, false);
    }

    //UiManager.Instance.mainUi.UpdateInfoUi(null, false);
}
