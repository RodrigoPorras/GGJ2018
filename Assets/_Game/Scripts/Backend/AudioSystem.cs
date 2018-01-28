using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Note: This approach loads the AudioClip using Resources.Load() dynamically.
// Once the resource is no longer needed (the audio clip has stopped playing), the
// resource is freed from memory via (Resources.UnloadAsset()), reducing runtime
// memory consumption

// this system can be extended to support multiple audio sources, and audio clips playing
// simultaneously (this is how a lot of Audio assets on the Asset Store manage resources)

public class AudioSystem : MonoBehaviour
{

    [SerializeField]
    AudioSource[] fXSources;
    [SerializeField]
    AudioSource musicSource;
    [SerializeField]
    string fxFolder;
    [SerializeField]
    string musicFolder;

    public bool muteFX;
    public bool muteMusic;

    AudioClip[] loadedResources = new AudioClip[20];

    private static AudioSystem instance = null;

    public static AudioSystem Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<AudioSystem>();

                if (instance == null)
                {
                    GameObject go = Instantiate(Resources.Load("AudioSystem")) as GameObject;
                    instance = go.GetComponent<AudioSystem>();
                    DontDestroyOnLoad(go);
                }
            }

            return instance;
        }
    }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
            loadedResources = new AudioClip[fXSources.Length];
    }

    private void Start()
    {
        if (PlayerPrefs.GetInt("Music") != 1)
            muteMusic = false;
        else
            muteMusic = true;
        if (PlayerPrefs.GetInt("FX") != 1)
            muteFX = false;
        else
            muteFX = true;
    }

    void Update()
    {
        musicSource.mute = muteMusic;
        for (int i = 0; i < fXSources.Length; i++)
        {
            if (!fXSources[i].isPlaying && loadedResources[i] != null)
            {
                Resources.UnloadAsset(loadedResources[i]);
                loadedResources[i] = null;
                fXSources[i].clip = null;
            }
        }
    }

    int x = 0;

    public void PlaySound(string resourceName)
    {
        if (!muteFX)
        {
            resourceName = fxFolder + resourceName;
            while (fXSources[x].isPlaying)
            {
                x++;
                if (x >= fXSources.Length)
                    x = 0;
            }      
            loadedResources[x] = Resources.Load(resourceName) as AudioClip;
            fXSources[x].clip = loadedResources[x];
            fXSources[x].Play();
            print(x);
            x++;
            if (x >= fXSources.Length)
                x = 0;
        } 
    }

    public void PlayMusic(string songName)
    {
        if (!muteMusic)
        {
            songName = musicFolder + songName;
            if (musicSource.clip != null)
            {
                musicSource.Stop();
                Resources.UnloadAsset(musicSource.clip);
            }
            musicSource.clip = Resources.Load(songName) as AudioClip;
            musicSource.Play(); 
        }
    }
}