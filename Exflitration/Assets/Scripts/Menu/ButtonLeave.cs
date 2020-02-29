using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonLeave : MonoBehaviour
{
    public Button Button_leave;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = Button_leave.GetComponent<Button>();
        btn.onClick.AddListener(play);
    }
    
    public void play()
    {
        SceneManager.LoadScene("Pause");
    }
}
