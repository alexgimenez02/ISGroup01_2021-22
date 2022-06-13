using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading;
using UnityEngine.UI;

public class PiecesInPosition : MonoBehaviour
{
    public int maxPieces;
    public GameObject winTextObject;

    public int posPieces;
    private bool wincont;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        posPieces = 0;
        winTextObject.SetActive(false);
        wincont = false;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (wincont) {
            timer += 0.1f;
             }
        if (posPieces == maxPieces)
        {
            wincont = true; 
            winTextObject.SetActive(true);
            Time.timeScale = 0;
            //Thread.Sleep(5000);

            
        }
    }
        

    public void addPiece()
    {
        posPieces++;
    }
    public void deletePiece()
    {
        posPieces--;
    }
    void LateUpdate()
    {
        if(timer >= 60) {
            Time.timeScale = 1;
            winTextObject.SetActive(false);
            timer = 0;
            wincont = false;
            SceneManager.LoadScene("Scene2");

        }

    }
}
