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
    public Button Next;
    GameObject obj;
    Button btn;
    bool IsWon;

    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        Level = scene.name;
        IsWon = obj.GetComponent<ResultLevels>().score();
        if(IsWon == true)
        {
            won();
            Gagner.SetActive(true);
            btn = Next.GetComponent<Button>();
            btn.onClick.AddListener(levels);
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
