using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectCheck : MonoBehaviour
{
    public Button Button_level1;
    public Button Button_level2;
    public Button Button_level3;
    Button btn;
    bool L1 = true;
    bool L2 = true;
    
    void Start()
    {
    	btn = Button_level1.GetComponent<Button>();
    	btn.onClick.AddListener(level1);
    }

    void Update()
    {
        if(L1 == true)
        {
        	btn = Button_level2.GetComponent<Button>();
        	btn.onClick.AddListener(level2);
        }
        if(L2 == true)
        {
        	btn = Button_level3.GetComponent<Button>();
        	btn.onClick.AddListener(level3);
        }
    }

    public void level1()
    {
    	SceneManager.LoadScene("Level 1");
    }

    public void level2()
    {
    	SceneManager.LoadScene("Level 2");
    }

    public void level3()
    {
    	SceneManager.LoadScene("Level 3");
    }
}
