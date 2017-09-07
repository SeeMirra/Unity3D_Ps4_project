using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
    //external varaible input
    public ParticleSystem Anchor;   //Particel system of the camera anchor object
    public GameController GC;       //GameController script

    //internal private variables
    private float sideMovInput;     //Input for side movement
    private float forwardMovInput;  //input for fov/back movement
    private Rigidbody rig;          //riged body of the object
    private bool charged;           //if ball is charged (true, false)

    // Use this for initialization
    void Start () {
        charged = false;                    //set charged to false
        rig = GetComponent<Rigidbody>();    //get Rig Body component of gameobject
	}
	
	// Update is called once per frame
	void Update () {

        forwardMovInput = Input.GetAxis("MoveVer") * 150;  //read input from vertical axis *150 (up down move)
        sideMovInput = Input.GetAxis("MoveHor") * 150;   //read input from horizontal axis *150(left right mov)

        if (forwardMovInput!=0) //if forward movment is not 0
        {
            rig.AddTorque(Camera.main.transform.right * forwardMovInput);   //apply torgue to teh rig body of the ball in relation to camera view
        }
        if (sideMovInput != 0)  //if side movement is not 0
        {
            rig.AddTorque(Camera.main.transform.forward * -sideMovInput);   //apply torgue to teh rig body of the ball in relation to camera view
        }
        if ((Input.GetButtonDown("Jump"))&&!charged)    //if jump is pressed and ball is not charged
        {
            rig.AddForce(Camera.main.transform.up + new Vector3(0,12,0),ForceMode.Impulse); //apply force to teh ball to it jump 
        }
        if ((Input.GetButtonDown("Drop")) && charged)    //if drop is pressed and player is charged
        {
            charged = false; //change current charge status to false to remove charge
        }
        if (GC.getLevel()==3) //if player is in level 3
        {
            if(Input.GetAxis("GravVer") > 0 || Input.GetKeyDown("1"))   //get key input
            {
                Physics.gravity = Camera.main.transform.up+new Vector3(0, 9.8f, 0);     //changing gravity direction to upwards
            }
            if (Input.GetAxis("GravVer") < 0 || Input.GetKeyDown("2"))  //get key input
            {      
                Physics.gravity = Camera.main.transform.up + new Vector3(0, -9.8f, 0); //changing gravity direction to downwards
            }
            if(Input.GetAxis("GravHor") < 0 || Input.GetKeyDown("3"))   //get key input
            {
                Physics.gravity = Camera.main.transform.right * -9.8f;                 //changing gravity direction to left in relation to the camera view
            }
            if(Input.GetAxis("GravHor") > 0 ||Input.GetKeyDown("4"))   //get key input
            {
                Physics.gravity = Camera.main.transform.right * 9.8f;                  //changing gravity direction to right in relation to the camera view
            }
        }

        if(charged) //if ball is charged
        {
           Anchor.enableEmission=true; //play particle system of the ball
        }
        else
        {
            Anchor.enableEmission = false; //stop particle system of the ball
        }
    }

    //fucntion to charge the ball to deliver charge to generator
    public void charge()
    {
        charged = !charged; //set charge to invert of current value
    }

    //getter for charge variable
    public bool readCharge()
    {
        return charged; //return charge value
    }

}
