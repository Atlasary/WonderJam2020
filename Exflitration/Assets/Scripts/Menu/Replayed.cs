using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Replayed : MonoBehaviour
{
    public Button Replay;
    Button btn;

    void Start()
    {
        btn = Replay.GetComponent<Button>();
    	btn.onClick.AddListener(replay);
    }

    void replay()
    {
        SceneManager.LoadScene("SelectLevels");
    }
}