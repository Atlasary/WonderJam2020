using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
/*
public class UIStressBarManager : MonoBehaviour
{
    // Insertion des variables globales

    public int STRESS_PROVOQUE_CONFORT_ZONE = 15;
    public float TEMPS_RESTANT = 60f;
    public bool TimeLeftStop = true;
    
    // Insertion des Game Objects
    public GameObject StressProgressBarPrefab;
    public GameObject SurvivorGroup;
    public GameObject Killer;

    private int SurvivorDownNumber = 0;
    private GameObject TimeLeftText;

    
    public void SurvivorDown()
    {
        if (SurvivorDownNumber > SurvivorGroup.Length)
        {

        }
    }

    public void StartTimer(float from)
    {
        TimeLeftStop = false;
        TEMPS_RESTANT = from;
        UnityEngine.PlayerLoop.Update();
        StartCoroutine(UpdateCoroutine());
    }

    public void ResetProgress()
    {
        foreach (GameObject survivor in SurvivorGroup)
        {
            survivor.GetComponent<Toggle>().isOn = false;
        }
        SurvivorDownNumber = 0;
    }
    
    public void ShowStressBarOnSurvivor(GameObject survivor)
    {
        GameObject inst = Instantiate(
            StressProgressBarPrefab,
            new Vector3(0, 0, 0),
            Quaternion.identity);
        inst.SetActive(false);
        inst.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        inst.transform.SetParent(HudLayout.transform.parent, false);
        // server.GetComponent<ServerModel>().setProgressBar(inst);
    }

    private IEnumerator UpdateCoroutine()
    {
        while (!TimeLeftStop)
        {
            TimeLeftText.GetComponent<TMP_Text>().text = string.Format("{0:0}:{1:00}", Minutes, Seconds);
            yield return new WaitForSeconds(0.2f);
        }
    }
}
*/