using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class itsinposition : MonoBehaviour
{
    public TangramPiece relativePiece;
    private bool once;
    // Start is called before the first frame update
    void Start()
    {
        once = false;
    }

    void Update()
    {
        //if(chicken.chickenHasPiece())
        if(Vector3.Distance(relativePiece.transform.position,transform.position) < 2.1f)
        {
            relativePiece.transform.position = transform.position;
            relativePiece.assertInPosition();
            if(!once)
            {
                Debug.Log(relativePiece.gameObject.name + " in position!");
                once = true;
            }
        }
        else
        {
            relativePiece.restartPiece();
        }

        if(Input.GetKeyDown(KeyCode.P))
            Debug.Log("Piece " + relativePiece.gameObject.name + " distance to position: " + Vector3.Distance(relativePiece.transform.position, transform.position));
    }
}
