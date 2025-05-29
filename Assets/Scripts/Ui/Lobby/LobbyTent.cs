using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyTent : MonoBehaviour, IInterctable
{
    public BuildCardData buildData;
    public GameObject normalTent;
    public GameObject upgadeTent;
    public string MyInfo()
    {
        string info = "Open Build Tab";


        return info;
    }
}
