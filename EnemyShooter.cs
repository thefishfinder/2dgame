using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine (Attack());
    }

    IEnumerator Attack()
    {
        Instantiate(bullet, transform.position + transform.right * 0.6f + transform.up * -0.5f, Quaternion.identity);
        yield return new WaitForSeconds(Random.Range(1, 3));
        StartCoroutine(Attack());
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
