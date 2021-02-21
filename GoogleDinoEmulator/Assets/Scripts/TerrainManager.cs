using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TerrainManager : MonoBehaviour
{
    public List<GameObject> groundObstacles;

    public GameObject player;

    public float yPosition = 0.05f;

    private bool obstacleLock = false;
    private float timeSinceLastInstantiation;

    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        StartCoroutine(GenerateGroundObstacle());
    }

    private void CreateObstacleAtX(float x)
    {
        timeSinceLastInstantiation = Time.time;

        var groundObstacle = groundObstacles.First();
        var obj = Instantiate(groundObstacle, new Vector3(player.transform.position.x + x, yPosition, 5.5f), new Quaternion(0, 0, 0, 0));
        obj.transform.localScale = new Vector3(0.35f, 0.35f, 0.35f);
    }

    private IEnumerator GenerateGroundObstacle()
    {
        if (Time.time >= timeSinceLastInstantiation + 3f)
        {
            CreateObstacleAtX(30);
        }

        if (obstacleLock == false)
        {
            var r = Random.Range(0, 10);
            obstacleLock = true;

            if (r == 1)
            {
                CreateObstacleAtX(30);
            }
            else if (r == 2 || r == 3)
            {
                CreateObstacleAtX(30);
                CreateObstacleAtX(32);
            }
            else if (r == 4 || r == 5)
            {
                CreateObstacleAtX(30);
                CreateObstacleAtX(32);
                CreateObstacleAtX(34);
            }

            yield return new WaitForSeconds(2);
            obstacleLock = false;
        }
    }
}