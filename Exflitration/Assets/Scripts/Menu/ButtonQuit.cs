using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonQuit : MonoBehaviour
{
    public Button Button_leave;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = Button_leave.GetComponent<Button>();
        btn.onClick.AddListener(quit);
    }
    
    public void quit()
    {
        Application.Quit();
    }
}
