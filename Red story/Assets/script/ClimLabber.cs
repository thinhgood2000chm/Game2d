using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimLabber : MonoBehaviour
{
    private bool isLadder;
    private bool isClimbing;
    public Rigidbody2D rigidbody;
    private  float vertical;
    public float speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxis("Vertical");
        if(isLadder && Mathf.Abs(vertical)> 0f)
        {
            isClimbing = true;
        }
    }
    private void FixedUpdate()
    {
        if (isClimbing)
        {
            rigidbody.gravityScale = 0f;
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, vertical * speed * Time.deltaTime);
        }
        else rigidbody.gravityScale = 4f;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ladder"))
        {
            isLadder = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ladder"))
        {
            isLadder = false;
            isClimbing = false;
        }
    }
}
