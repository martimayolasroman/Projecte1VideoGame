using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float jumpForce, jumpAmount, noOfJump, gravityChangeValue, jumpKeyPressTime, jumpKeyPressRecord;
    [HideInInspector] public bool isJumping;
    private Rigidbody2D playerRB;

    private void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            noOfJump = jumpAmount;
            isJumping = false;
        }
    }

    private void Update()
    {
        jumpKeyPressRecord -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpKeyPressRecord = jumpKeyPressTime;
        }
    }

    private void FixedUpdate()
    {
        if (jumpKeyPressRecord > 0)
        {
            if (noOfJump > 0)
            {
                playerRB.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                noOfJump--;
                isJumping = true;
                jumpKeyPressRecord = 0;
            }
        }
        GravityChanger();
    }

    private void GravityChanger()
    {
        if (playerRB.velocity.y < 0)
        {
            playerRB.gravityScale = gravityChangeValue;
        }
        else if (playerRB.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            playerRB.gravityScale = gravityChangeValue;
        }
        else
        {
            playerRB.gravityScale = 1;
        }
    }
}
