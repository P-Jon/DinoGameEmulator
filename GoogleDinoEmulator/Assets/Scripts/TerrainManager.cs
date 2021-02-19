using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TerrainManager : MonoBehaviour
{
    public List<GameObject> groundObstacles;

    public GameObject player;

    private float yPosition = 0.05f;

    private List<GameObject> instantiatedObjects = new List<GameObject>();

    private bool obstacleLock = false;

    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        StartCoroutine(GenerateGroundObstacle());
    }

    private IEnumerator GenerateGroundObstacle()
    {
        var r = Random.Range(0, 500);
        if (r == 5 && obstacleLock == false)
        {
            obstacleLock = true;
            var groundObstacle = groundObstacles.First();
            var obj = Instantiate(groundObstacle, new Vector3(player.transform.position.x + 12, yPosition, 0), new Quaternion(0, 0, 0, 0));
            obj.transform.localScale = new Vector3(0.35f, 0.35f, 0.35f);
            instantiatedObjects.Add(obj);
            yield return PopObstacles();
        }
    }

    private IEnumerator PopObstacles()
    {
        yield return new WaitForSeconds(2);

        obstacleLock = false;

        if (instantiatedObjects != null || instantiatedObjects.Count > 0)
            Destroy(instantiatedObjects.First());
    }
}