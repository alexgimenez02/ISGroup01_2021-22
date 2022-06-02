using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{

    public GameObject shield;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Awake()
    {
        shield.SetActive(true);
    }
    public void Sleep()
    {
        shield.SetActive(false);
    }

    public bool isActive()
    {
        return shield.active;
    }
}
