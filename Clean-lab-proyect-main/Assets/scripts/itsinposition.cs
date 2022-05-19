using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itsinposition : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
        // Find all colliders that overlap
        BoxCollider myCollider = GetComponent<BoxCollider>();
        //Debug.Log(myCollider.gameObject.name);
        Collider[] otherColliders = Physics.OverlapBox(myCollider.bounds.min, myCollider.bounds.max);

        // Check for any colliders that are on top
        /*bool isUnderneath = false;
        foreach (var otherCollider in otherColliders)
        {
            if (otherCollider.transform.position.z < this.transform.position.z)
            {
                isUnderneath = true;
                break;
            }
        }*/
        RaycastHit hit;
        float collisionCheckDistance = 2.0f;
        

        // Take the appropriate action
        if (GetComponent<Rigidbody>().SweepTest(Vector3.back, out hit, collisionCheckDistance))
        {
            GameObject obj1 = GameObject.Find(transform.name);
            Renderer cubeRenderer = obj1.GetComponent<Renderer>();
            //Call SetColor using the shader property name "_Color" and setting the color to green
            cubeRenderer.material.SetColor("_Color", Color.green);
        }

    }
}
