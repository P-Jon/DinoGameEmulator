using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleToGameHandler : MonoBehaviour
{
    public GameObject titleUI;
    public GameObject transitionUI;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void StartGame()
    {
        titleUI.SetActive(false);
        transitionUI.SetActive(true);
        StartCoroutine(loadScene());
    }

    private IEnumerator loadScene()
    {
        yield return new WaitForSeconds(3);
        Debug.Log("Loading Scene");
        SceneManager.LoadScene("Main_Scene-1");
    }
}