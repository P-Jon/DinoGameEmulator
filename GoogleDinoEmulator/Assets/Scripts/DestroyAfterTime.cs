using System.Collections;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    public int secondsToDestroy;

    public void Start()
    {
        StartCoroutine(destroyAfterTime());
    }

    private IEnumerator destroyAfterTime()
    {
        yield return new WaitForSeconds(secondsToDestroy);
        Destroy(this.gameObject);
    }
}