using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperGang1 : MonoBehaviour
{
    public float forceY = 500f;
    public float jumptime = 1f;
    private Rigidbody2D myRigidbody;
    private Animator myAnimator;

    void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Pause());
        StartCoroutine(Attack());
    }

    IEnumerator Pause()
    {
        yield return new WaitForSeconds(.1f);
    }

    IEnumerator Attack()
    {
        myRigidbody.AddForce(new Vector2(0, forceY));
        myAnimator.SetBool("attack", true);
        yield return new WaitForSeconds(jumptime);
        myAnimator.SetBool("attack", false);
        StartCoroutine(Attack());
    }
}