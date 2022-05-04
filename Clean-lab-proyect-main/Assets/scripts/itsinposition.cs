using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itsinposition : MonoBehaviour
{
    // Start is called before the first frame update
    void OnMouseDown()
    {
        // Find all colliders that overlap
        BoxCollider2D myCollider = GetComponent<BoxCollider2D>();
        Collider2D[] otherColliders = Physics2D.OverlapAreaAll(myCollider.bounds.min, myCollider.bounds.max);

        // Check for any colliders that are on top
        bool isUnderneath = false;
        foreach (var otherCollider in otherColliders)
        {
            if (otherCollider.transform.position.z < this.transform.position.z)
            {
                isUnderneath = true;
                break;
            }
        }

        //rigidbody.SweepTest(Vector3.back, out hit);

        // Take the appropriate action
        if (isUnderneath)
        {
            var obj1 = GameObject.Find("piece1");
            var cubeRenderer = obj1.GetComponent<Renderer>();
            //Call SetColor using the shader property name "_Color" and setting the color to green
            cubeRenderer.material.SetColor("_Color", Color.green);
        }

    }
}
