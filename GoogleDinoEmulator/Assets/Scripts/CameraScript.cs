using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject player;
    public int xOffset;
    private void Update()
    {
        this.gameObject.transform.position = new Vector3((player.gameObject.transform.position.x + xOffset), 2, this.gameObject.transform.position.z);
    }
}