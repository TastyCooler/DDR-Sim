using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

    static MusicManager instance = null;

    public AudioClip startClip;

    private AudioSource music;

    // Use this for initialization
    void Awake () {
        Singleton();
	}
	


    void Singleton()
    {
        //Debug.Log("Music player Awake " + GetInstanceID());
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            print("Duplicate music player self-destructing!");
        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
            music = GetComponent<AudioSource>();
            music.clip = startClip;
            music.loop = true;
            music.Play();

        }
    }
}
