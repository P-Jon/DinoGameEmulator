using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float jumpHeight;
    public float baseSpeed;
    public float playerScore; // Public for debugging
    public float playerSpeed;
    public Transform groundCheck;

    private bool isGround = false;
    private Vector3 playerVelocity;

    private void Start()
    {
        playerVelocity = Vector2.zero;
        playerSpeed = baseSpeed;
    }

    private void Update()
    {
        isGround = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        playerScore = transform.position.x / 4;

        if (playerScore >= 100f)
            playerSpeed = 40;
        else if (playerScore > 12)
            playerSpeed = playerScore;

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
        }
    }
}