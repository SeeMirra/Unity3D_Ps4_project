using UnityEngine;
using System.Collections;

public class RespawnScript : MonoBehaviour {

    //External input placeholder
    public Transform Spawn; //respawn point on Character death

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    //trigger if player collides with plane
    private void OnTriggerEnter(Collider obj)
    {
        Physics.gravity = new Vector3(0, -9.8f, 0); //set gravity to down
        obj.transform.position=Spawn.position;      //Reset player to Spawn position
    }
}
