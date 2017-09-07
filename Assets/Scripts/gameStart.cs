using UnityEngine;
using System.Collections;

public class gameStart : MonoBehaviour {
    //external variable input
    public cameraControl Camera;                    //camera control script
    public Ball Player;                             //player control script
    public transporterControlScript transporter;    //transporter script
    public GameController GC;                       //game controller script
    public Animator anim_Origin;                    //Animator Origin
    public Animator anim_Target;                    //Animator destination
    
    // Use this for initialization
    void Start () {
        Cursor.visible=true;                        //set cursor to visible
        Camera.enabled = false;                     //turn off camera script
        Player.enabled = false;                     //turn off player script
        Cursor.lockState = CursorLockMode.Confined; //lock cursor to game window
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //called when new game is started
    public void StartNewGame()
    {
        Cursor.visible = false; //set cursor to invisible
        Camera.enabled = true;  //enable camera control
        Player.enabled = true;  //enable player control
        GC.changeLayover();     //change ui layover
    }
}
