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
    private Dictionary<string,float> redPieces = new Dictionary<string,float>();
    private string parentPiece;


    // Start is called before the first frame update
    void Start()
    {
        playerPos = transform.position;
        lastPosition = playerPos;
        waitTime = 0.0f;
        holdPiece = false;
        parentPiece = "pieces";
        for(int i = 0; i < 7; i++)
        {
            string name = parentPiece + "/piece" + (i + 1);
            GameObject piece = GameObject.Find(name); 
            if(piece.gameObject.GetComponent<MeshRenderer>()) //Triangulos
            {                 
                if(piece.gameObject.GetComponent<MeshRenderer>().material.ToString() == (color + " (Instance) (UnityEngine.Material)"))
                {
                    redPieces.Add(name,Vector3.Distance(piece.gameObject.transform.position,playerPos));
                }
            }
            else{
                if(piece.gameObject.GetComponent<SpriteRenderer>()) //Rombos
                {
                    if(piece.gameObject.GetComponent<SpriteRenderer>().material.ToString() == (color + " (Instance) (UnityEngine.Material)"))
                    {
                        redPieces.Add(name,Vector3.Distance(piece.gameObject.transform.position,playerPos));
                    }
                }
            }
        }  
    }

    // Update is called once per frame
    void Update()
    {
        //TODO
        /*
         1. Tiempo de espera cuando esta quieto | Done
         2. Mover pieza | Done
         3. Generar escudo | ToBeDone
         4. Dejar pieza | Done
         
         
        */
        playerPos = transform.position;
        if(waitTime >= fixTime)
        {
            Debug.Log("Entro aqui!");
            Progress progbar;
            if (transform.TryGetComponent(out progbar)) progbar.deactivateProgressBar();
        }
        if(holdPiece && currentPiece != null)
        {
            //Debug.Log("Moving piece");
            currentPiece.transform.position = playerPos + new Vector3(0.0f,2.0f,0.0f);
        }

        if(waitTime >= fixTime && !holdPiece)
        {

            float minDist = 200000000000;
            string closePiece = "";
            foreach (string key in redPieces.Keys)
            {
                minDist = Mathf.Min(minDist,redPieces[key]);
                if(minDist == redPieces[key]) closePiece = key;
            }

            if(closePiece != "" && redPieces[closePiece] < 32)
            {
                GameObject piece = GameObject.Find(closePiece);
                currentPiece = piece;
                holdPiece = true;
                //Debug.Log("Hold piece!");
            }

            //Debug.Log("Hold or shield piece");
            
            waitTime = 0.0f;
            
        }
        else if(waitTime >= fixTime && holdPiece)
        {
            //Drop piece

            //Debug.Log("Drop piece");
            waitTime = 0.0f;
            holdPiece = false;
            currentPiece.transform.position = playerPos + new Vector3(0.0f,30.0f,0.0f);
        }
        if(!holdPiece)
        {
            List<string> keys = new List<string>(redPieces.Keys);
            foreach(string key in keys)
            {
                GameObject piece = GameObject.Find(key);
                redPieces[key] = Vector3.Distance(piece.gameObject.transform.position,playerPos);
            }
        }
        if(Input.GetKeyDown(KeyCode.Q))
        {
            holdPiece = false;
            currentPiece.transform.position = playerPos + new Vector3(0.0f, 30.0f, 0.0f);
            Debug.Log("Debug Piece Drop!");
        }
        if(Input.GetKeyDown(KeyCode.T))
            Debug.Log("WaitTime is: " + waitTime);

    }

    void LateUpdate()
    {
          
       float distToLastPos = Vector3.Distance(playerPos,lastPosition);
        Progress progbar;
        if (distToLastPos < 0.3f)
        {
            if (waitTime == 0.0f)
            {
                if(transform.TryGetComponent(out progbar)) progbar.activateProgressBar();
            }
            waitTime += Time.deltaTime;
        }
        else
        {
            if (transform.TryGetComponent(out progbar)) progbar.deactivateProgressBar();
            waitTime = 0.0f;
            lastPosition = playerPos;
        }
        
    }

    public Vector3 getPlayerPosition()
    {
        return playerPos;
    }
}
