using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class secret_platform : MonoBehaviour
{
    public GameObject secretplatform2;

    void Start()
    {
        secretplatform2 = GameObject.Find("secret platform 2");
        secretplatform2.gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Player")
        {
            secretplatform2.gameObject.SetActive(true);
        }
    }
}
