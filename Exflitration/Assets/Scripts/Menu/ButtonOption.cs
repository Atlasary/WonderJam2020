using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonOption : MonoBehaviour
{
    public Button Button_options;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = Button_options.GetComponent<Button>();
        btn.onClick.AddListener(play);
    }
    
    public void play()
    {
        SceneManager.LoadScene("OptionsPause");
    }
}
