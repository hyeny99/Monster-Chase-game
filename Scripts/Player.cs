using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    float movementX;

    float moveForce = 10f;
    float jumpForce = 11f;

    private string WALK_ANIMATION = "Walk";
    private string GROUND_TAG = "Ground";
    private string MONSTER_TAG = "Monster";
    private bool isGrounded = true;


    private Animator anim;
    private SpriteRenderer sr;
    private Rigidbody2D myBody;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        myBody = GetComponent<Rigidbody2D>();
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
        AnimatePlayer();
    }
    
    // Usually used when physics calculation is involved (like jumping)
    private void FixedUpdate()
    {
        PlayerJumpKeyBoard();
    }
    void PlayerMoveKeyboard()
    {
        movementX = Input.GetAxisRaw("Horizontal");  // -1(left), 0(still), 1(right)
        transform.position += new Vector3(movementX, 0, 0) * moveForce * Time.deltaTime;
        // Debug.Log(Time.deltaTime);
    }

    void AnimatePlayer()
    {
        // walks to the right
        if(movementX > 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = false;
        }
        // walks to the left
        else if(movementX < 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = true;
        }
        // stands still
        else
        {
            anim.SetBool(WALK_ANIMATION, false);
        }
    }

    void PlayerJumpKeyBoard()
    {
        // Input.GetButton = pressed and released
        // Input.GetButtonDown = pressed
        // Input.GetButtonUp = released
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag(MONSTER_TAG))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(MONSTER_TAG))
            Destroy(gameObject);
    }
}
