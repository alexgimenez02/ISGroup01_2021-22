using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TangramPiece : MonoBehaviour
{
    private bool inPosition;
    void Start()
    {
        inPosition = false;
    }

    public void assertInPosition()
    {
        inPosition = true;
    }
    public bool getInPosition()
    {
        return inPosition;
    }
    public void restartPiece()
    {
        Start();
    }
}
