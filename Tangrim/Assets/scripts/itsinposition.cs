using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading;
using UnityEngine.UI;

public class itsinposition : MonoBehaviour
{
    public TangramPiece relativePiece;
    private bool once;
    public Material material1;
    public Material material2;
    public GameObject Object;
    public PiecesInPosition checker;
    // Start is called before the first frame update
    void Start()
    {
        once = false;
    }

    void Update()
    {
        //if(chicken.chickenHasPiece())
        if (Vector3.Distance(relativePiece.transform.position, transform.position) < 2.1f)
        {
            relativePiece.transform.position = transform.position;
            relativePiece.assertInPosition();
            if (!once)
            {
                Debug.Log(relativePiece.gameObject.name + " in position!");
                once = true;
                checker.addPiece();
               
                    if (Object.gameObject.GetComponent<MeshRenderer>())
                    { //triángulos

                        Object.GetComponent<MeshRenderer>().material = material1;
                    }

                    if (Object.gameObject.GetComponent<SpriteRenderer>())
                    {

                        Object.GetComponent<SpriteRenderer>().material = material1;
                    }//rombos
                }
            }
        
        else
        {
            relativePiece.restartPiece();
            if (once)
            {
                checker.deletePiece();
                once = false;
                if (Object.gameObject.GetComponent<MeshRenderer>())
                { //triángulos

                    Object.GetComponent<MeshRenderer>().material = material2;
                }

                if (Object.gameObject.GetComponent<SpriteRenderer>())
                {

                    Object.GetComponent<SpriteRenderer>().material = material2;
                }//rombos
            }
        }

        if (Input.GetKeyDown(KeyCode.P)) {
            Debug.Log("Piece " + relativePiece.gameObject.name + " distance to position: " + Vector3.Distance(relativePiece.transform.position, transform.position));
        }
    }
}
