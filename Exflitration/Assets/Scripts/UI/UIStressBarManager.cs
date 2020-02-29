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

    public int SurvivorNumber;
    private int SurvivorDownNumber = 0;

    // Gestion du temps
    private GameObject TimeLeftText;
    private float Minutes;
    private float Seconds;

    public void SurvivorDown()
    {
        if (SurvivorDownNumber > SurvivorNumber)
        {

        }
    }

    public void StartTimer(float from)
    {
        

    }
    public void GameOver()
    {

    }

    public void ResetProgress()
    {
        foreach (GameObject survivor in SurvivorGroup)
        {
            survivor.GetComponent<Toggle>().isOn = false;
        }
        SurvivorDownNumber = 0;
    }
    
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }

    public void ShowStressBarOnSurvivor(GameObject survivor)
    {
        GameObject inst = Instantiate(StressProgressBarPrefab, new Vector3(0, 0, 0), Quaternion.identity);
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