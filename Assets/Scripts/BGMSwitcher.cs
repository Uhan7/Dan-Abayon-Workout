using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMSwitcher : MonoBehaviour
{
    private AudioSource aSource;

    public AudioClip[] bgms;

    private AudioClip musicToPlay;

    private void Awake()
    {
        aSource = GetComponent<AudioSource>();
    }

    void Start()
    {

    }

    void Update()
    {
       if (!aSource.isPlaying)
        {
            musicToPlay = bgms[Random.Range(0, bgms.Length-1)];
            aSource.PlayOneShot(musicToPlay);
        }
    }
}
