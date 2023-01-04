using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
   void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Player")
        {
            //target.gameObject.GetComponent<PlayerScript>().isAlive = false;
            //target.gameObject.GetComponent<PlayerScript>().myAnimator.SetBool("Dead", true);
            //target.gameObject.GetComponent<PlayerScript>().reset.SetActive(true);
            //Destroy(target.gameObject);
            Destroy(gameObject);
        }
        if (target.gameObject.tag == "ground")
        {
            Destroy (gameObject);
        }
        if (target.gameObject.tag == "deadly")
        {
            Destroy(gameObject);
        }
        if (target.gameObject.tag == "damage")
        {
            Destroy(gameObject);
        }
    }
    
}
