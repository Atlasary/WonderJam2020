using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndParty2 : MonoBehaviour
{
	bool end = true;
	public Button Win;
	Button btn;

	void Start()
	{
		btn = Win.GetComponent<Button>();
    	btn.onClick.AddListener(res);
	}

    void res()
    {
        if(end == false)
        {
        	SceneManager.LoadScene("Lose");
        }
        else
        {
        	SceneManager.LoadScene("Win3");
        }
    }
}
