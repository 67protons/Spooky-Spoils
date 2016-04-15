using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SoundManager : MonoBehaviour {

    public AudioClip[] sfxClips;
    public AudioClip[] bgClips;
    public AudioClip currentBGClip;

    public AudioSource sfxSource;
    public AudioSource bgSource;

    public string Scene1;
    public string Scene2;
    public string MainMenu;


    public static SoundManager instance = null;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)//enforces singleton pattern.
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        PlayBGMusic(bgClips[1]);
    }


    //use this to change bgmusic.
    void OnLevelWasLoaded(int level)
    {
        Debug.Log(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "BlockRoom")
            PlayBGMusic(bgClips[0]);
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "BossRoom2")
            PlayBGMusic(bgClips[4]);
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Foyer3")
            PlayBGMusic(bgClips[3]);
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "StatueRoom1")
            PlayBGMusic(bgClips[2]);
    }

    internal void PlaySFX(AudioClip clip)
    {
        sfxSource.clip = clip;
        sfxSource.Play();
    }

    internal void PlayBGMusic(AudioClip clip)
    {
        bgSource.clip = clip;
        bgSource.Play();
    }
}
