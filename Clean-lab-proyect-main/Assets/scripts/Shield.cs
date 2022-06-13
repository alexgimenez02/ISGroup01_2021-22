using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{

    public GameObject shield;
    public  void Awake()
    {
        shield.SetActive(true);
    }
    public  void Sleep()
    {
        shield.SetActive(false);
    }

    public bool isActive()
    {
        return shield.active;
    }
}
