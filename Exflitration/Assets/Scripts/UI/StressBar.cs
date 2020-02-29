using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StressBar : MonoBehaviour
{

    public Slider volumeSlider;
    public float ETAT_STRESS_INITIAL = 0f;
    public float duration = 0.5f;
    private float ETAT_STRESS_ACTUEL = 0f;

    void Start()
    {
        GameObject temp = GameObject.Find("StressSlider");
        if (temp != null)
        {
            this.volumeSlider = temp.GetComponent<Slider>();
            if (volumeSlider != null)
                this.volumeSlider.normalizedValue = ETAT_STRESS_INITIAL;
            else
                Debug.LogError("[" + temp.name + "] - Does not contain a Slider Component!");
        }
        else
            Debug.LogError("Could not find an active GameObject named Volume Slider !");

    }

    public void Update()
    {
        if (checkIfExist())
        {
            this.ETAT_STRESS_ACTUEL = this.volumeSlider.normalizedValue;
        }
    }
    public bool checkIfExist()
    {
        if (this.volumeSlider != null)
            return true;
        else
            return false;
    }

    public Slider GetSlider()
    {
       return GameObject.Find("StressSlider").GetComponent<Slider>();
    }

    public void AddProgress(float percentage)
    {
        if (checkIfExist())
        {
            this.volumeSlider = this.GetSlider();
            if (this.volumeSlider.normalizedValue + percentage > 1f)
                this.volumeSlider.normalizedValue = 1f;
            else if (this.volumeSlider.normalizedValue < 0f)
                this.volumeSlider.normalizedValue = 0f + percentage;
            else
            {
                StopCoroutine("CountTo");
                StartCoroutine("CountTo", this.volumeSlider.normalizedValue + percentage);
                this.volumeSlider.normalizedValue = this.volumeSlider.normalizedValue + percentage;
            }
        }
    }

    IEnumerator CountTo(float target)
    {
        float start = this.volumeSlider.normalizedValue;
        for (float timer = 0; timer < duration; timer += Time.deltaTime)
        {
            float progress = timer / duration;
            this.volumeSlider.normalizedValue = (int)Mathf.Lerp(start, target, progress);
            yield return null;
        }
        this.volumeSlider.normalizedValue = target;
    }

}
