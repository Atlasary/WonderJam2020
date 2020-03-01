using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StressBar : MonoBehaviour
{

    public UnityEngine.UI.Slider volumeSlider;
    public float duration = 0.5f;
    private float ETAT_STRESS_ACTUEL = 0.2f;

    void Start()
    {
        volumeSlider = GetComponent<UnityEngine.UI.Slider>();
        volumeSlider.normalizedValue = ETAT_STRESS_ACTUEL;
    }
    
    public void setProgress(float value)
    {
        if (value <= 1.0f && value >= 0.0f)
            volumeSlider.normalizedValue = value;
    }

    public void AddProgress(float percentage)
    {
            if (this.volumeSlider.normalizedValue + percentage > 1.0f)
                this.volumeSlider.normalizedValue = 1.0f;
            else if (this.volumeSlider.normalizedValue < 0.0f)
                this.volumeSlider.normalizedValue = 0.0f;
            else
            {
                StopCoroutine("CountTo");
                StartCoroutine("CountTo", this.volumeSlider.normalizedValue + percentage);
            }
    }

    public void LessProgress(float percentage)
    {
        if (this.volumeSlider.normalizedValue + percentage > 1.0f)
            this.volumeSlider.normalizedValue = 1.0f;
        else if (this.volumeSlider.normalizedValue < 0.0f)
            this.volumeSlider.normalizedValue = 0.0f;
        else
        {
            StopCoroutine("CountTo");
            StartCoroutine("CountTo", this.volumeSlider.normalizedValue - percentage);
        }
    }
    IEnumerator CountTo(float target)
    {
        float start = this.volumeSlider.normalizedValue;
        for (float timer = 0; timer < duration; timer += Time.deltaTime)
        {
            float progress = timer / duration;
            this.volumeSlider.normalizedValue = Mathf.Lerp(start, target, progress);
            yield return null;
        }
        this.volumeSlider.normalizedValue = target;
    }

}
    