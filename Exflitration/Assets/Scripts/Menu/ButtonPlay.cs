using System.Collections;
using System;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPlay : MonoBehaviour
{
    public Button Button_play;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = Button_play.GetComponent<Button>();
        btn.onClick.AddListener(play);
    }
    
    public void play()
    {
        SceneManager.LoadScene("SelectLevels");
    }
}
