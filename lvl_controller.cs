using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lvl_controller : MonoBehaviour
{
    public void Lvl1()
    {
        SceneManager.LoadScene("lvl.1");
    }
    public void Lvl2()
    {
        SceneManager.LoadScene("lvl.2");
    }
    public void Lvlsecret()
    {
        SceneManager.LoadScene("lvl.secret");
    }
    public void menu()
    {
        SceneManager.LoadScene("menu");
    }
    public void winscreen()
    {
        SceneManager.LoadScene("winscreen");
    }
}
