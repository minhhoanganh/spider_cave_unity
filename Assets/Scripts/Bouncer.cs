using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : MonoBehaviour
{
    public float force = 500f;

    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    IEnumerator AnimateBouncy()
    {
        anim.Play("Up");
        yield return new WaitForSeconds(.5f);
        anim.Play("Down");
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Player")
        {
            target.gameObject.GetComponent<Player>().BouncePlayerWithBouncy(force);
            StartCoroutine(AnimateBouncy());
        }
    }
}
