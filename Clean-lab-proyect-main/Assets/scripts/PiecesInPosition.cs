using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading;
using UnityEngine.UI;

public class PiecesInPosition : MonoBehaviour
{
    public int maxPieces;
    private Text wintext;

    private int posPieces;
    // Start is called before the first frame update
    void Start()
    {
        posPieces = 0;
        wintext.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (posPieces == maxPieces)
        {
            wintext.text = "You win!";
            Time.timeScale = 0;
            Thread.Sleep(5000);
            SceneManager.LoadScene("Scene2");
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
}
