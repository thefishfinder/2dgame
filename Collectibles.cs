using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{ 
    void Start()
    {
        if (Door.instance != null)
        {
            Door.instance.collectiblesCount++;
        }
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Player")
        {
            Destroy(gameObject);
            if (Door.instance != null)
            {
                Door.instance.DecrementCollectibles();
            }
        }
    }
}
