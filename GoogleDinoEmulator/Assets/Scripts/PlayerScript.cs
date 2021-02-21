using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public float jumpHeight;
    public float baseSpeed;
    public float playerScore; // Public for debugging
    public float playerSpeed;
    public Transform groundCheck;

    public Text scoreText;

    private bool isGround = false;
    private Vector3 playerVelocity;
    public GameUIManager _uiManager;

    private void Start()
    {
        playerVelocity = Vector2.zero;
        playerSpeed = 10;
        StartCoroutine(rampUpSpeed());
    }

    private void Update()
    {
        isGround = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        playerScore = transform.position.x / 2;

        StartCoroutine(updateUI());

        playerVelocity.x = Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime;

        if ((Input.GetKey(KeyCode.W)) && (isGround))
        {
            playerVelocity.y = jumpHeight;
            isGround = false;
        }
        else
        {
            playerVelocity.y = GetComponent<Rigidbody2D>().velocity.y;
        }

        playerVelocity.x = playerSpeed;
    }

    private void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = playerVelocity;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Time.timeScale = 0;
            _uiManager.GameOverScreen();
        }
    }

    private IEnumerator updateUI()
    {
        yield return new WaitForEndOfFrame();
        scoreText.text = $"Score: {playerScore.ToString("0")}";
        yield return new WaitForEndOfFrame();
    }

    private IEnumerator rampUpSpeed()
    {
        yield return new WaitForSeconds(2);

        if (playerSpeed < 20)
        {
            playerSpeed += 2;
            StartCoroutine(rampUpSpeed());
        }
    }
}