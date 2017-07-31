using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    public float jumpHeight;
    public float baseSpeed;
    public float playerScore; // Public for debugging

    public Transform groundCheck;

    bool isGround = false;
    Vector3 playerVelocity;
    

	void Start () {
        playerVelocity = Vector2.zero;    
    }

    void Update()
    {
        isGround = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        playerScore = transform.position.x / 4;
        float playerSpeed = baseSpeed;
        if (playerSpeed != 20) { // Make sure the speed caps so it doesn't become impossible
            if (playerScore > 10) {
                playerSpeed = (baseSpeed * (playerScore / 10));
            }
        }
        else{
            playerSpeed = 30;
        }

        playerVelocity.x = Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime;

        if ((Input.GetKey(KeyCode.W)) && (isGround)) {
            playerVelocity.y = jumpHeight;
            isGround = false;
        }
        else{
            playerVelocity.y = GetComponent<Rigidbody2D>().velocity.y;
        }
        playerVelocity.x = playerSpeed;
    }
    void FixedUpdate(){
        GetComponent<Rigidbody2D>().velocity = playerVelocity;
    }
    
    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("Enemy")){
            Time.timeScale = 0;
        }
    }
}
