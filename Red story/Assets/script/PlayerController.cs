using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool isLadder;
    private bool isClimbing;
    private Rigidbody2D rigidbody;
    private float vertical;
    public float speedRun = 5;
    private Animator animator;
    bool isground = true;
    public float jumbHeight = 8;
    // Start is called before the first frame update
    bool facingRight ;
    bool attack;
    private bool isJumb; 

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        facingRight = true;
        isground = true;
        isJumb = false;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
 /*       vertical = Input.GetAxis("Vertical");
        if (isLadder && Mathf.Abs(vertical) > 0f)
        {
            isClimbing = true;
        }
        Debug.Log(vertical);*/
        float move = Input.GetAxis("Horizontal");
        if (!this.animator.GetCurrentAnimatorStateInfo(0).IsTag("attack")){
            rigidbody.velocity = new Vector2(move * speedRun, rigidbody.velocity.y);
        }

        animator.SetFloat("speed", Mathf.Abs(move));
     
        if (move> 0 && !facingRight) // đổi từ quay trái qua quay phải
        {
            flip();
        }
        else if (move< 0 && facingRight) // đổi từ quay phải qua quay trái 
        {
            flip();
        }
        if (Input.GetKey(KeyCode.Space))
        {
     
            if (isground)
            {
                isJumb = true;
                isground = false;
              
                rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumbHeight);
       
            }
        }
        animator.SetBool("isJumb", isJumb);
        // attack 1

        HandleAttack();

/*        if (isClimbing)
        {
            rigidbody.gravityScale = 0f;
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, vertical * speedRun * Time.deltaTime);
        }
        else rigidbody.gravityScale = 2f;*/
        /*  float attk1 = Input.GetAxis("Fire1");

          animator.SetFloat("attk1", Mathf.Abs(attk1));
          rigidbody.velocity = Vector2.zero;
          float attk2 = Input.GetAxis("Fire2");
          Debug.Log(attk2);
          animator.SetFloat("attk2", Mathf.Abs(attk2));
          rigidbody.velocity = Vector2.zero;*/
        /*        float attk3 = Input.GetAxis("Fire3");
                animator.SetFloat("attk2", Mathf.Abs(attk3));*/

    }

    void HandleAttack()
    {
        float attk1 = Input.GetAxis("Fire1");
        animator.SetFloat("attack1", Mathf.Abs(attk1));
        float attk2 = Input.GetAxis("Fire2");
        animator.SetFloat("attack2", Mathf.Abs(attk2));
        if (attk1> 0.1 || attk2 > 0.1) // thiết lập khi đang chạy bấm đánh sẽ ko bị lướt 
        {
            rigidbody.velocity = Vector2.zero;
        }
            //attack = false;
       
    }
    void flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if( collision.gameObject.tag =="ground")
        {
            isJumb = false;
            isground = true;
        }
 /*       if (collision.gameObject.tag=="ladder")
        {
            Debug.Log("da vO");
            isLadder = true;
        }*/
    }
  /*  private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="ladder")
        {
            isLadder = false;
            isClimbing = false;
        }
    }*/



}
