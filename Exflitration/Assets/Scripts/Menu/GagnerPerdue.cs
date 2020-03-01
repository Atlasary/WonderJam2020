using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GagnerPerdue : MonoBehaviour
{
    bool L1;
    bool L2;
    bool L3;
    bool L4;
    public GameObject Gagner;
    public GameObject Perdre;
    string Level;
    bool IsWon = false;

    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        Level = scene.name;
        if(IsWon == true)
        {
            won();
            levels();
            Gagner.SetActive(true);
        }
        else
        {
            lose();
            Perdre.SetActive(true);
        }
    }

    void won()
    {
        if(Level == "Level 1")
        {
            L1 = true;
        }
        if(Level == "Level 2")
        {
            L2 = true;
        }
        if(Level == "Level 3")
        {
            L3 = true;
        }
        if(Level == "Level 4")
        {
            L4 = true;
        }
    }

    void lose()
    {
        if(Level == "Level 1")
        {
            L1 = false;
        }
        if(Level == "Level 2")
        {
            L2 = false;
        }
        if(Level == "Level 3")
        {
            L3 = false;
        }
        if(Level == "Level 4")
        {
            L4 = false;
        }
    }

    void levels()
    {
        if(L1 == true)
        {
            SceneManager.LoadScene("Level 2");
        }
        if(L2 == true)
        {
            SceneManager.LoadScene("Level 3");
        }
        if(L3 == true)
        {
            SceneManager.LoadScene("Level 4");
        }
    }
}
