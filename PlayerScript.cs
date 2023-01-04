using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D myRigidbody;
    private Animator myAnimator;
    public float moveSpeed;
    private bool facingRight;
    [SerializeField]
    private Transform[] groundPoints; //creates an array of points to collide with the ground (actually game objects)
    [SerializeField]
    private float groundRadius; //creates the size of the colliders
    [SerializeField]
    private LayerMask whatIsGround; //defines what is ground
    private bool isGrounded; //can be set to true or false depending on out position
    private bool jump; //can be set to true or false when we press the spacebar
    [SerializeField]
    private float jumpForce;//allows us to determine the magnitude of the jump
    public bool isAlive;
    public GameObject reset;
    private Slider healthBar;
    public float health = 3f;
    private float healthBurn = 1f;
    [SerializeField]
    private float hurtSeconds = 5f;
    private bool isInvincible;
    public GameObject secretplatform2;
    public GameObject secretplatform3;
    public GameObject teleportpoint;

    // Start is called before the first frame update
    void Start()
    {
        facingRight = true;
        myRigidbody = GetComponent<Rigidbody2D>();  //a variable to control the player's body
        myAnimator = GetComponent<Animator>();
        isAlive = true;
        reset.SetActive(false);
        healthBar = GameObject.Find("health slider").GetComponent<Slider>();
        healthBar.minValue = 0f;
        healthBar.maxValue = health;
        healthBar.value = healthBar.maxValue;
        StartCoroutine(blinking());
        secretplatform2.SetActive(false);
        secretplatform3.SetActive(false);
        teleportpoint = GameObject.Find("teleportpoint");
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal"); //a variable that stores the value of our horizontal movement
        //Debug.Log(horizontal);
        if (isAlive)
        {
            PlayerMovement(horizontal); //function that controls the player on the x axis
            Flip(horizontal);
            HandleInput();
        }
        else
        {
            return;
        }
        isGrounded = IsGrounded();
        
        if(isAlive == true)
        {
            reset.SetActive(false);
        }

    }

    //function definitions
    private void PlayerMovement(float horizontal)
    {
        if (isGrounded && jump)
        {
            isGrounded = false;
            jump = false;
            myRigidbody.AddForce(new Vector2(0, jumpForce));
            myAnimator.SetBool("jumping", true);
        }
        myRigidbody.velocity = new Vector2(horizontal * moveSpeed, myRigidbody.velocity.y); //adds velocity to the player's body on the x axis
        myAnimator.SetFloat("speed", Mathf.Abs(horizontal));
    }

    private void Flip(float horizontal)
    {
        if(horizontal<0 && facingRight || horizontal>=0 && !facingRight)
        {
            facingRight = !facingRight;  //reset the bool to the opposite value
            Vector2 theScale = transform.localScale;    //creating a vector2 and storing the local scale values
            theScale.x *=-1;        //
            transform.localScale = theScale;
        }
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        }
        
    }

    //function to test for collisions between the array of groundPoints and the Ground LayerMask

    private bool IsGrounded()
    {
        if (myRigidbody.velocity.y <= 0)
        {
            //if the player is not moving vertically, test each of the Player's groundPoints for collision with Ground
            foreach (Transform point in groundPoints)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, groundRadius, whatIsGround);
                for (int i = 0; 1 < colliders.Length; i++)
                {
                    if (colliders[i].gameObject != gameObject) //if any of the colliders in the array of groundPoints comes into contact with another gameobject, return true.
                    {
                        return true;
                    }
                }
            }
        }
        return false; //if the player is not moving along the y axis, return false.
    }
    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "ground")
        {
            myAnimator.SetBool("jumping", false);
        }
        if (target.gameObject.tag == "deadly")
        {
            ImDead();
            healthBar.value = 0f;
        }
        if (target.gameObject.tag == "damage")
        {
            UpdateHealth();
            StartCoroutine(hurt());
        }
        if (target.gameObject.tag == "secret1")
        {
            myAnimator.SetBool("jumping", false);
            secretplatform2.SetActive(true);
        }
        if (target.gameObject.tag == "secret2")
        {
            myAnimator.SetBool("jumping", false);
            secretplatform3.SetActive(true);
        }
        if (target.gameObject.tag == "teleplatform")
        {
            transform.position = teleportpoint.transform.position;
        }
    }

    void UpdateHealth()
    {
        if (!isInvincible)
        {
            if (health > 0)
            {
                health -= healthBurn;
                healthBar.value = health;
            }
            if (health <= 0)
            {
                ImDead();
            }
            StartCoroutine(IFrames());
        }
    }

    IEnumerator IFrames()
    {
        isInvincible = true;
        yield return new WaitForSeconds(hurtSeconds);
        isInvincible = false;
    }

    public void ImDead()
    {
        isAlive = false;
        myAnimator.SetBool("dead", true);
        reset.SetActive(true);
    }

    public IEnumerator hurt()
    {
        myAnimator.SetBool("hurting 0", true);
        yield return new WaitForSeconds(hurtSeconds);
        myAnimator.SetBool("hurting 0", false);
    }

    public IEnumerator blinking()
    {
        yield return new WaitForSeconds(Random.Range(1f, 6f));
        myAnimator.SetBool("blinking", true);
        yield return new WaitForSeconds(.3f);
        myAnimator.SetBool("blinking", false);
        StartCoroutine(blinking());
    }
}
