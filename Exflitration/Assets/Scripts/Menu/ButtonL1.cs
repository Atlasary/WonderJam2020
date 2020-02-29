using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonL1 : MonoBehaviour
{
    public Button Button_level1;

    void Start()
    {
        Button btn = Button_level1.GetComponent<Button>();
        btn.onClick.AddListener(play);
    }
    
    public void play()
    {
        SceneManager.LoadScene("Level 1");
    }
}
