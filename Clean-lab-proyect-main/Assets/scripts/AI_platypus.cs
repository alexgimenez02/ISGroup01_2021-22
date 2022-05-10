using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class AI_platypus : MonoBehaviour
{
    private Vector3 playerPos;
    public Transform target;
    public float speed = 200f;
    public float nextWaypointDist = 3f;
    Path path;
    int currentWaypoint = 0;
    bool reached = false;
    Seeker seeker;
    Rigidbody2D rb;
    private Dictionary<string, float> redPieces = new Dictionary<string, float>();

    // Start is called before the first frame update
    void Start()
    {
        playerPos = transform.position;
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        for (int i = 0; i < 7; i++)
        {
            string name = "piece" + (i + 1);
            GameObject piece = GameObject.Find(name);
            if (piece.gameObject.GetComponent<MeshRenderer>()) //Triangulos
            {
                redPieces.Add(name, Vector3.Distance(piece.gameObject.transform.position, playerPos));
            }
            else
            {
                if (piece.gameObject.GetComponent<SpriteRenderer>()) //Rombos
                {   
                    redPieces.Add(name, Vector3.Distance(piece.gameObject.transform.position, playerPos));
                }
            }
        }

        InvokeRepeating("UpdatePath", 0f, .5f);
    }

    void UpdatePath()
    {
        float minDist = 200000000000;
        string closePiece = "";
        foreach (string key in redPieces.Keys)
        {
            minDist = Mathf.Min(minDist, redPieces[key]);
            if (minDist == redPieces[key]) closePiece = key;
        }
        GameObject closest_piece = GameObject.Find(closePiece);
        target = closest_piece.gameObject.transform;
        if (seeker.IsDone()) seeker.StartPath(rb.position, target.position, OnPathComplete);
    }

    void OnPathComplete(Path p) {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (path == null) return;
        if (currentWaypoint >= path.vectorPath.Count)
        {
            reached = true;
            return;
        }
        else
        {
            reached = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDist) currentWaypoint++;
    }
}
