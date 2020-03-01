using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menue : MonoBehaviour
{
    public Button Menu;
    Button btn;

    void Start()
    {
        btn = Menu.GetComponent<Button>();
    	btn.onClick.AddListener(menu);
    }

    void menu()
    {
        SceneManager.LoadScene("Principal");
    }
}