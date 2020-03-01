using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOnScene : MonoBehaviour
{
    private AudioSource audio;
    public AudioClip intro;
    public AudioClip ballad;
    public AudioClip pursuit;
    public AudioClip death;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("ThrowMusicinit");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator ThrowMusicInit()
    {
        audio = GetComponent<AudioSource>();
        audio.clip = intro;
        audio.Play();
        yield return new WaitForSeconds(intro.length);
        audio.clip = ballad;
        audio.Play();
    }


}
