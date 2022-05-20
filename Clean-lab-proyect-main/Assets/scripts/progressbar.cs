using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class progressbar : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform LoadingBar;
    public Transform center;
    public float currentAmount;
    public float speed;
    private bool inPosition;
    // Update is called once per frame
    void Update() {
        if (currentAmount < 100) {
            currentAmount += speed * Time.deltaTime;
        }

        if (inPosition) LoadingBar.GetComponent<Image>().fillAmount = currentAmount / 100;
        else
        {
            FillToZero();
        }

    }
    public void modifyBarPosition(Vector3 position)
    {
        LoadingBar.transform.position = position + new Vector3(0.0f,40.0f,0.0f);
        center.transform.position = position + new Vector3(0.0f, 40.0f, 0.0f);
    }
    public void Awake()
    {
        LoadingBar.gameObject.SetActive(true);
        center.gameObject.SetActive(true);
        inPosition = true;
    }
    public void Sleep()
    {
        LoadingBar.gameObject.SetActive(false);
        center.gameObject.SetActive(false);
        inPosition = false;
    }
    public void setInPosition(bool st)
    {
        inPosition = st;
    }
    public void FillToZero()
    {
        LoadingBar.GetComponent<Image>().fillAmount = 0;
        currentAmount = 0;
    }
}
