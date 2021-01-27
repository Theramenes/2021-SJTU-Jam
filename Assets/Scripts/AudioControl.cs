using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioControl : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClipSO[] audioClips;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySERandom()
    {
        audioClips[Random.Range(0, audioClips.Length)].Play(audioSource);
    }


    public void PlaySE1()
    {
        if (audioClips.Length >= 1)
            audioClips[0].Play(audioSource);
    }

    public void PlaySE2()
    {

        if (audioClips.Length >= 2)
            audioClips[1].Play(audioSource);
    }

    public void PlaySE3()
    {

        if (audioClips.Length >= 3)
            audioClips[2].Play(audioSource);
    }
}
