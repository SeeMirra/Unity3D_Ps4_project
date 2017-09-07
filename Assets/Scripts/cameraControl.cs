using UnityEngine;
using System.Collections;

public class cameraControl : MonoBehaviour {
    //local private variables
    private float camSideMov;   //camera side movement value
    private float camUpMov;     //camera up movement value

    private GameObject player;  //gameobject of the player
    private GameObject anchor;  //gameobject of the anchor object
	
    // Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");    //find gameobject of the player
        anchor = GameObject.FindGameObjectWithTag("Anchor");    //find gameobject of the anchor 
	}
	
	// Update is called once per frame
	void Update () {
        camSideMov = Input.GetAxis("CamHor");  //get input from X axis
        camUpMov = Input.GetAxis("CamVer");    //get input from Y axis
        
        anchor.transform.position = player.transform.position;  //set anchor position to player position

        Camera.main.transform.RotateAround(anchor.transform.position, Camera.main.transform.up, camSideMov);    //rotate the camera around the anchor object
        Camera.main.transform.RotateAround(anchor.transform.position, Camera.main.transform.right, camUpMov);   //rotate the camera around the anchor object

        Camera.main.transform.LookAt(anchor.transform.position);    //forca camera to look at anchor in relation to world grid
    }
}
