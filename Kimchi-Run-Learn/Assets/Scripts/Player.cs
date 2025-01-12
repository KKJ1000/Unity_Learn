using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Settings")]
    public float jumpForce;

    [Header("References")]
    public Rigidbody2D playerRigidBody;
    public Animator playerAnimator;

    private bool isGrounded = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            playerRigidBody.AddForceY(jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
            playerAnimator.SetInteger("state", 1);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Platform")
        {
            if (!isGrounded)
            {
                playerAnimator.SetInteger("state", 2);
            }
            isGrounded = true;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("ENEMY"))
        {

        }
        else if(collision.CompareTag("FOOD"))
        {

        }
        else if(collision.CompareTag("GOLDEN"))
        {

        }
    }
}
