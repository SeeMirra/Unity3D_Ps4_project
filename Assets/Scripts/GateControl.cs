using UnityEngine;
using System.Collections;

public class GateControl : MonoBehaviour {
    //External input placeholder
    public Animator GateLeft;   //animator for left gate
    public Animator GateRight;  //animatro of right gate

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //trigger when enterign
    void OnTriggerEnter(Collider obj)
    {
        GateLeft.SetTrigger("open");    //trigger left gate to open
        GateRight.SetTrigger("open");   //trigger right gate to open
    }
}
