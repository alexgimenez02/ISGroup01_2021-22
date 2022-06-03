using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{

    public GameObject shield;
    private bool colision;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        colision = false;
        timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        /*checkColision();
        if(colision)
        {
            Debug.Log("Chicken colision");
        }
        colision = false;*/
        timer += 0.1f;
    }
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
    private void checkColision()
    {
        if(timer > 30.0f)
        {
            colision = true;
            timer = 0.0f;
        }
    }
}
