using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class OnOff : MonoBehaviour
{
    public Button Button_son;
    public AudioSource audioData;
    public TextMeshProUGUI Button_sontext;
    // Start is called before the first frame update
    void Start()
    {
        Button_sontext = Button_son.GetComponentInChildren<TextMeshProUGUI>();
        Button_son.onClick.AddListener(changeTxt);
        audioData = GetComponent<AudioSource>();
    }
    
    public void changeTxt()
    {
        string btn = Button_sontext.text;
        if(btn == "On")
        {
            Button_sontext.text = "Off";
            audioData.mute = !audioData.mute;
        }
        else
        {
            Button_sontext.text = "On";
            audioData.mute = !audioData.mute;
        }
    }

    void Update()
    {
        Button_son.onClick.AddListener(changeTxt);        
    }
}
