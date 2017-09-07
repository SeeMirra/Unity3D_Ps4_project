using UnityEngine;
using System.Collections;

public class teleportation : MonoBehaviour {
    //external Interface Variables
    public Transform target;            //destination tranform component
    public Transform player;            //PLayer transform component
    public GameController GC;           //game controller script
    
    // Use this for initialization
    void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {

    }
    
    //Transport function for player movement
    public void transport()
    {
        if (GC.getLevel() < 5)  //if level is below 5
        {
            player.position = target.position + new Vector3(0, 5, 0);   //move player to target destination

            GC.changeLevel();                                           //change level
        }
    }
}
