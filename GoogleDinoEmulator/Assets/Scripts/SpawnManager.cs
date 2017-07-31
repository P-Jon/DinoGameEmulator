using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    public GameObject groundPrefab;
    private GameObject groundClone;

    public Transform spawnTarget;

    float groundOffset;
    Vector3 groundSpawnPos;

	void Start () {
        groundSpawnPos = spawnTarget.position;
        groundOffset = groundPrefab.transform.localScale.x / 2;
    }

    void Update () {
	}

    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("Player")){
            Debug.Log("Picked it up.");
            GameObject groundClone = Instantiate(groundPrefab, new Vector3((groundSpawnPos.x + groundOffset), groundSpawnPos.y, groundSpawnPos.z), spawnTarget.rotation) as GameObject as GameObject;
        }
    }
}
