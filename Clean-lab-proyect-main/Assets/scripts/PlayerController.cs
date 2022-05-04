using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 playerPos, lastPosition;
    private float waitTime;
    private bool holdPiece;
    private float fixTime = 2.0f;
    public string color;
    private GameObject currentPiece;


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

        if(holdPiece && currentPiece != null)
        {
            Debug.Log("Moving piece");
            currentPiece.transform.position = playerPos + new Vector3(0.0f,2.0f,0.0f);
        }

        if(waitTime >= fixTime && !holdPiece)
        {
            //Show options
            //if(player on top of piece) 1. grab option 2. shield option
            for(int i = 0; i < 7; ++i)
            {
                float distToPiece;
                string name = "piece" + (i + 1);
                GameObject piece = GameObject.Find(name); 
                
                if(piece.gameObject.GetComponent<MeshRenderer>()) //Triangulos
                {
                    
                    //Debug.Log("Piece: " + piece.gameObject.GetComponent<MeshRenderer>().material.ToString());
                    //Debug.Log("Player: " + color + "(Instance) (UnityEngine.Material)");
                    
                    if(piece.gameObject.GetComponent<MeshRenderer>().material.ToString() == (color + " (Instance) (UnityEngine.Material)"))
                    {
                        distToPiece = Vector3.Distance(piece.gameObject.transform.position,playerPos);
                        //Debug.Log("Player distance to piece " + (i+1) + distToPiece);
                        if(distToPiece < 42)
                        {
                            holdPiece = true; //Debug.Log("Hold piece"); 
                            currentPiece = piece;
                            break;
                        }
                    }
                }else 
                {
                    if(piece.gameObject.GetComponent<SpriteRenderer>()) //Rombos
                    {
                        //Material name when running -> color (Instance) (UnityEngine.Material)
                        if(piece.gameObject.GetComponent<SpriteRenderer>().material.ToString() == (color + " (Instance) (UnityEngine.Material)"))
                        {
                            //Debug.Log("Same color: " + color);
                            distToPiece = Vector3.Distance(piece.gameObject.transform.position,playerPos);
                            if(distToPiece < 42)
                            {
                                holdPiece = true; //Debug.Log("Hold piece"); 
                                currentPiece = piece;
                                break;
                            }
                        }
                    }
                }
            
            }
            //else shield option

            //Debug.Log("Hold or shield piece");
            waitTime = 0.0f;
        }
        else if(waitTime >= fixTime && holdPiece)
        {
            //Drop piece

            Debug.Log("Drop piece");
            waitTime = 0.0f;
            holdPiece = false;
        }
        if(Input.GetKeyDown(KeyCode.Q))
        {
            holdPiece = false;
        }
    }

    void LateUpdate()
    {
          
       float distToLastPos = Vector3.Distance(playerPos,lastPosition); 
       
        if (distToLastPos < 0.3f)
        {
            waitTime += Time.deltaTime;
        }
        else
        {
            waitTime = 0.0f;
            lastPosition = playerPos;   
        }
        
    }

    public Vector3 getPlayerPosition()
    {
        return playerPos;
    }
}
