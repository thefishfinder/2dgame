using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class secretdoor : MonoBehaviour
{

    public static secretdoor instance;

    private Animator anim;
    private BoxCollider2D box;
    public GameObject next;
  
    public GameObject player;
    public GameObject door;
    void Awake()
    {
        MakeInstance();
        anim = GetComponent<Animator>();
        box = GetComponent<BoxCollider2D>();
        player = GameObject.Find("player");
    }

    void MakeInstance()
    {
        if (instance == null)
            instance = this;

    }
    
    void Update()
    {
        if (door.GetComponent<Door>().collectiblesCount == 5)
        {
            StartCoroutine(OpenDoor());
            
        }
    }

    IEnumerator OpenDoor()
    {
        anim.Play("open_secret");
        yield return new WaitForSeconds(.7f);
        box.isTrigger = true;
    }
   
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Player")
        {
            Destroy(player);
            SceneManager.LoadScene("lvl.secret");
        }
    }
}
