using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonL3 : MonoBehaviour
{
    public Button Button_level3;

    void Start()
    {
        Button btn = Button_level3.GetComponent<Button>();
        btn.onClick.AddListener(play);
    }
    
    public void play()
    {
        SceneManager.LoadScene("Level 3");
    }
}
