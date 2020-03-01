using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public Button Next;
    Button btn;

    void Start()
    {
        btn = Next.GetComponent<Button>();
    	btn.onClick.AddListener(level);
    }

    void level()
    {
        SceneManager.LoadScene("Principal");
    }
}
