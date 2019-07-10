using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveForce = 20f;
    public float jumbForce = 700f;
    public float maxVelocity = 4f;

    private bool grounded;
    private Rigidbody2D myBody;
    private Animator anim;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        PlayerWalkKeyboard();
    }

    void PlayerWalkKeyboard()
    {
        float forceX = 0f;
        float forceY = 0f;

        float vel = Mathf.Abs(myBody.velocity.x);
        float h = Input.GetAxisRaw("Horizontal"); // convert keyboard input to number

        if(h > 0)
        {
            if(vel < maxVelocity)
            {
                forceX = moveForce;
            }
            Vector3 scale = transform.localScale;
            scale.x = 1f;
            transform.localScale = scale;

            anim.SetBool("Walk", true);
        } else if (h < 0)
        {
            if (vel < maxVelocity)
            {
                forceX = -moveForce;
            }
            Vector3 scale = transform.localScale;
            scale.x = -1f;
            transform.localScale = scale;

            anim.SetBool("Walk", true);
        } else if (h == 0)
        {
            anim.SetBool("Walk", false);
        }

        if(Input.GetKey(KeyCode.Space))
        {
            if(grounded)
            {
                grounded = false;
                forceY = jumbForce;
            }
        }

        myBody.AddForce(new Vector2(forceX, forceY));
    }

    public void BouncePlayerWithBouncy(float force)
    {
        if(grounded)
        {
            grounded = false;
            myBody.AddForce(new Vector2(0, force));
        }
    }


    private void OnCollisionEnter2D(Collision2D target)
    {
        if(target.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }


}
