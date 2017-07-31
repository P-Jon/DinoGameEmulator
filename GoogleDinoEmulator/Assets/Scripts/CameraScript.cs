using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    public GameObject player;
	
	void Update () {                                        // x has an offset so the player is displayed to the left -> OG: 11, 1
        this.gameObject.transform.position = new Vector3((player.gameObject.transform.position.x + 6 ), 2, this.gameObject.transform.position.z);	
	} 
}
