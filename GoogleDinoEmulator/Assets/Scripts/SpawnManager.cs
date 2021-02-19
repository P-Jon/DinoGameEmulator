using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject groundPrefab;
    private GameObject groundClone;

    public Transform spawnTarget;

    private float groundOffset;
    private Vector3 groundSpawnPos;

    private void Start()
    {
        groundSpawnPos = spawnTarget.position;
        groundOffset = groundPrefab.transform.localScale.x / 2;
    }

    private void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject groundClone = Instantiate(groundPrefab, new Vector3((groundSpawnPos.x + groundOffset), groundSpawnPos.y, groundSpawnPos.z), spawnTarget.rotation) as GameObject as GameObject;
            StartCoroutine(destroyObject());
        }
    }

    private IEnumerator destroyObject()
    {
        yield return new WaitForSeconds(5);
        Destroy(transform.parent.gameObject);
    }
}