using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Move : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private bool moveLeft;
    private bool moveRight;
    private bool moveUp;
    private bool moveDown;
    public bool upAndDown;
    private bool jump;
    public bool dkJump;
    public bool dkPush;
    public float speed = 3;
    private float lowY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        dkPush = false;
        upAndDown = false;
        lowY = gameObject.transform.position.y;
    }

    public void onLeft()
    {
        moveLeft = true;
    }

    public void offLeft()
    {
        moveLeft = false;
    }

    public void onUp()
    {
        moveUp = true;
    }

    public void offUp()
    {
        moveUp = false;
    }

    public void onDown()
    {
        moveDown = true;
    }
    public void offDown()
    {
        moveDown = false;
    }
    public void onJump()
    {
        jump = true;
        AudioManager.instance.Play("Jump");
    }

    public void offJump()
    {
        jump = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            dkJump = true;
        }
        else if (collision.gameObject.CompareTag("box"))
        {
            dkPush = true;
            dkJump = true;
        }
        else if (collision.gameObject.CompareTag("stair"))
        {
            dkJump = true;
        }
        else if (collision.gameObject.CompareTag("stairUpnDown"))
        {
            dkJump = true;
            transform.parent = collision.transform;
        }
        else if (collision.gameObject.CompareTag("trap"))
        {
            playerManager.gameOver = true;
            gameObject.SetActive(false);
            AudioManager.instance.Play("GameOver");
        }          
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("box"))
        {
            dkPush = false;
        }
        else if (collision.gameObject.CompareTag("stairUpnDown"))
        {
            transform.parent = null;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("stair"))
        {
            upAndDown = true;
            rb.bodyType = RigidbodyType2D.Kinematic;
            dkJump = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("stair"))
        {
            upAndDown = false;
            rb.bodyType = RigidbodyType2D.Dynamic;


        }
        dkJump = true;
    }

    public void onRight()
    {
        moveRight = true;
    }

    public void offRight()
    {
        moveRight = false;
    }

    private void SetAcivePushAnimation(bool active)
    {
        anim.SetBool("push", active);
    }

    private void SetActiveIdleAnimation(bool active)
    {
        anim.SetBool("Idle", active);
    }

    private void SetActiveMovingAnimation(bool active)
    {
        anim.SetBool("right", active);
    }

    private void SetActiveJumpAnimation(bool active)
    {
        anim.SetBool("jump", active);
    }

    private void SetActiveUpAndDownAnimation(bool active)
    {
        anim.SetBool("upAndDown", active);
    }

    private void flip()
    {
        gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x * -1, gameObject.transform.localScale.y);
    }
    private void MovePlayer()
    {
        if (moveLeft)
        {
            if (gameObject.transform.localScale.x > 0)//neu mat nhan vat dang quay ben phai
            {
                flip();
            }
            else if (dkPush)
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
                SetAcivePushAnimation(true);
                SetActiveMovingAnimation(false);
                SetActiveIdleAnimation(false);
                SetActiveUpAndDownAnimation(false);
            }
            else
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
                SetActiveIdleAnimation(false);
                SetActiveMovingAnimation(true);
                SetActiveUpAndDownAnimation(false);
                SetAcivePushAnimation(false);
            }

        }

        else if (moveRight)
        {
            if (gameObject.transform.localScale.x < 0)//neu mat nhan vat dang quay ben trai
            {
                flip();
            }
            else if (dkPush)
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
                SetAcivePushAnimation(true);
                SetActiveMovingAnimation(false);
                SetActiveIdleAnimation(false);
            }
            else
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
                SetActiveMovingAnimation(true);
                SetActiveIdleAnimation(false);
                SetAcivePushAnimation(false);

            }
        }

        else if (jump)
        {
            if (dkJump)
            {
                    dkJump = false;
                    rb.velocity = new Vector2(rb.velocity.x, speed + 2);
                    SetActiveJumpAnimation(true);
                    SetAcivePushAnimation(false);
            }
        }
            else if (upAndDown)
            {
                if (moveDown)
                {
                    rb.velocity = new Vector2(rb.velocity.x, (speed - 1)*-1);
                    SetActiveUpAndDownAnimation(true);
                SetActiveIdleAnimation(false);
                SetActiveMovingAnimation(false);
                }
                else if (moveUp)
                {
                    rb.velocity = new Vector2(rb.velocity.x, speed - 1);
                    SetActiveUpAndDownAnimation(true);
                SetActiveIdleAnimation(false);
                SetActiveMovingAnimation(false);
                }
                else
                {
                rb.velocity = new Vector2(0, 0);
                SetActiveIdleAnimation(true);
                SetActiveUpAndDownAnimation(false);
            }
        }


        else
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
                SetActiveIdleAnimation(true);
                SetActiveMovingAnimation(false);
                SetActiveJumpAnimation(false);
                SetAcivePushAnimation(false);
                dkPush = false;
            
                SetActiveUpAndDownAnimation(false);
                
        }
        }


    // Update is called once per frame
    void Update()
    {
        MovePlayer();

    }
}
