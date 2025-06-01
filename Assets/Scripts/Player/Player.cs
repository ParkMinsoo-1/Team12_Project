using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerController _playerController;
    public Interaction _interaction;
    public PlayerStatus _status;
    private void Awake()
    {
        PlayerManager.Instance.Player = this;
        _playerController = GetComponent<PlayerController>();
        _interaction = GetComponent<Interaction>();
        _status = GetComponent<PlayerStatus>();
    }
    private void Start()
    {
        Debug.Log("�÷��̾� ��ŸƮ");
        StartCoroutine(PlayerCunsume());
    }

    public IEnumerator PlayerCunsume()
    {
        Debug.Log("�񵿱� �÷��̾� ���� ���� ����");
        while (!_playerController.isDead)
        {
            Debug.Log("���¾���");
            _status.update();
            yield return new WaitForSeconds(5);
        }

        yield break;
    }
}
