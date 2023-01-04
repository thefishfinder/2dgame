using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectibles2 : MonoBehaviour
{
    void Start()
    {
        if (door2.instance != null)
        {
            door2.instance.collectiblesCount++;
        }
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Player")
        {
            Destroy(gameObject);
            if (door2.instance != null)
            {
                door2.instance.DecrementCollectibles();
            }
        }
    }
}
