using UnityEngine;
using System.Collections;

public class NewMusicScene : MonoBehaviour
{

    public AudioClip roundETCmusic;


    private AudioSource source;


    // Use this for initialization
    void Awake()
    {
        source = GetComponent<AudioSource>();
    }


    void OnLevelWasLoaded(int level)
    {
        if (level == 2)
        {
            source.clip = roundETCmusic;
            source.Play();
        }

    }
}