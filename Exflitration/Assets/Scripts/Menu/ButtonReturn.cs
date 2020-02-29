using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonReturn : MonoBehaviour
{
    public Button Button_return;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = Button_return.GetComponent<Button>();
        btn.onClick.AddListener(play);
    }
    
    public void play()
    {
        SceneManager.LoadScene("Principal");
    }
}
