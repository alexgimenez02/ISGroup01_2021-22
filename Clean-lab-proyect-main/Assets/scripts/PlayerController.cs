using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 playerPos, lastPosition;
    private float waitTime;
    private bool holdPiece;
    private float fixTime = 2.0f;


    // Start is called before the first frame update
    void Start()
    {
        playerPos = transform.position;
        lastPosition = playerPos;
        waitTime = 0.0f;
        holdPiece = false;
    }

    // Update is called once per frame
    void Update()
    {
        //TODO
        /*
         1. Tiempo de espera cuando esta quieto
         2. Mover pieza
         3. Generar escudo
         4. Dejar pieza
         
         
        */
        playerPos = transform.position;

        if(waitTime >= fixTime && !holdPiece)
        {
            //Show options
            //if(player on top of piece) 1. grab option 2. shield option
            //else shield option

            Debug.Log("Hold or shield piece");
            holdPiece = true;
            waitTime = 0.0f;
        }
        else if(waitTime >= fixTime && holdPiece)
        {
            //Drop piece

            Debug.Log("Drop piece");
            waitTime = 0.0f;
            holdPiece = false;
        }

    }
    void LateUpdate()
    {
        
        if (playerPos == lastPosition)
        {
            waitTime += Time.deltaTime;
        }
        else
        {
            waitTime = 0.0f;
        }
        lastPosition = playerPos;
    }

    
}
