using UnityEngine;
using System.Collections;

public class Bridge : MonoBehaviour {
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //trigger event when entered
    private void OnTriggerEnter(Collider obj)
    {
        obj.transform.parent = gameObject.transform; //set collider object to child of bridge trigger
    }

    //trigger event when left
    private void OnTriggerExit(Collider obj)
    {
        obj.transform.parent = null;    //set collider to have no parent
        obj.transform.localScale = new Vector3(4, 4, 4);
    }
}
