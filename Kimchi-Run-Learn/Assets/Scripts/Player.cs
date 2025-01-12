using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Settings")]
    public float jumpForce;

    [Header("References")]
    public Rigidbody2D playerRigidBody;
    public Animator playerAnimator;

    public BoxCollider2D playerCollider;

    private bool isGrounded = true;

    private int lives = 3;
    private bool isInvincible = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            playerRigidBody.AddForceY(jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
            playerAnimator.SetInteger("state", 1);
        }
    }

    void KillPlayer()
    {
        playerCollider.enabled = false;
        playerAnimator.enabled = false;
        playerRigidBody.AddForceY(jumpForce, ForceMode2D.Impulse);
    }

    void Hit()
    {
        lives -= 1; // 생명력 1 감소
        if (lives == 0)
        {
            KillPlayer();
        }
    }

    void Heal()
    {
        lives = Mathf.Min(3, lives + 1);
    }

    void StartInvincible()
    {
        isInvincible = true;
        Invoke("StopInvincible", 3f);
    }

    void StopInvincible()
    {
        isInvincible = false;
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
            if(!isInvincible)
            {
                Destroy(collision.gameObject);
                Hit();
            }
        }
        else if(collision.CompareTag("FOOD"))
        {
            Destroy(collision.gameObject);
            Heal();
        }
        else if(collision.CompareTag("GOLDEN"))
        {
            Destroy(collision.gameObject);
            StartInvincible();
        }
    }
}
