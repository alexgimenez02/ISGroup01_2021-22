using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class progressbar : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform LoadingBar;
    public float currentAmount;
    public float speed;
    // Update is called once per frame
    void Update() {
        if (currentAmount < 100) {
            currentAmount += speed * Time.deltaTime;
        }

        LoadingBar.GetComponent<Image>().fillAmount = currentAmount / 100;

}
}
