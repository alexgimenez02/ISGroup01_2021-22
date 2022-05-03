using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Progress : MonoBehaviour {
    public float barDisplay; //current progress
    public PlayerController playerController;
    public Vector3 pos;
    public Vector2 size = new Vector2(30,20);
    public Texture2D emptyTex;
    public Texture2D fullTex;
 
    /*void OnGUI() {
       //draw the background:
        GUI.BeginGroup(new Rect(pos.x, pos.z, size.x, size.y));
        GUI.Box(new Rect(pos.x,pos.z, size.x, size.y), emptyTex);
 
         //draw the filled-in part:
        GUI.BeginGroup(new Rect(pos.x,pos.z, size.x * barDisplay, size.y));
        GUI.Box(new Rect(pos.x,pos.z, size.x, size.y), fullTex);
        GUI.EndGroup();
        GUI.EndGroup();
    }*/
 
    void Update() {
       //for this example, the bar display is linked to the current time,
       //however you would set this value based on your desired display
       //eg, the loading progress, the player's health, or whatever.
       barDisplay = Time.time;
       new Rect(pos.x, pos.z, size.x, size.y);
       new Rect(pos.x,pos.z, size.x * barDisplay, size.y);
       pos = playerController.getPlayerPosition() + new Vector3(0.0f, 10.0f, 0.0f);
       //   barDisplay = MyControlScript.staticHealth;
    }
}
