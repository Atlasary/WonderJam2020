using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StressBar : MonoBehaviour
{
    Slider volumeSlider;

    // Use this for initialization
    public void SetProgress(float percentage)
    {
        GameObject temp = GameObject.Find("Volume Slider");
        if (temp != null)
        {
            volumeSlider = temp.GetComponent<Slider>();
            if (volumeSlider != null)
                volumeSlider.normalizedValue = percentage;
            else
                Debug.LogError("[" + temp.name + "] - Does not contain a Slider Component!");
        }
        else
            Debug.LogError("Could not find an active GameObject named Volume Slider!");

    }
    public void AddProgress(float progress)
    {
        GameObject temp = GameObject.Find("Volume Slider");
        if (temp != null)
        {
            volumeSlider = temp.GetComponent<Slider>();
            if (volumeSlider != null)
                volumeSlider.normalizedValue = volumeSlider.normalizedValue + progress;
            else
                Debug.LogError("[" + temp.name + "] - Does not contain a Slider Component!");
        }
        else
            Debug.LogError("Could not find an active GameObject named Volume Slider!");
    }

    public float GetProgress()
    {
        GameObject temp = GameObject.Find("Volume Slider");
        if (temp != null)
        {
            volumeSlider = temp.GetComponent<Slider>();
            if (volumeSlider != null)
                return volumeSlider.normalizedValue;
            else
                return 0;
        }
        else
            return 0;
    }

    /* public Image progress;

     public void SetProgress(float percentage)
     {
         mySlider = GameObject.Find("sliderName").GetComponent(UnityEngine.UI.Slider);

         if (percentage > 1f)
             progress.fillAmount = 1f;
         else if (percentage < 0f)
             progress.fillAmount = 0;
         else
             progress.fillAmount = percentage;
     }

     public void AddProgress(float progress)
     {
         SetProgress(this.progress.fillAmount + progress);
     }

     public float GetProgress()
     {
         return progress.fillAmount;
     }*/

}
