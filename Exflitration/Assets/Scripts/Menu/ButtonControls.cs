using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonControls : MonoBehaviour
{
    public Button Button_controls;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = Button_controls.GetComponent<Button>();
        btn.onClick.AddListener(play);
    }
    
    public void play()
    {
        SceneManager.LoadScene("MenuControls");
    }
}
