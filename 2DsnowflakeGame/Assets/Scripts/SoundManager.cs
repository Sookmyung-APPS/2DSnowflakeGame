using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource bgsound;
    private bool muted = false;
    //public AudioClip[] bglist;
    public static SoundManager instance;
    private void Awake()
    {
        
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(instance);
            //SceneManager.sceneLoaded += OnSceneLoad;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    //bgm 배열
    /*private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
       for(int i = 0; i<bglist.Length;i++)
       {
           if (arg0.name == bglist[i].name)
               BgSoundPlay(bglist[i]);
       }
    }*/

    public void SFXPlay(string sfxName, AudioClip clip)
    {
        GameObject go = new GameObject(sfxName + "Sound");
        AudioSource audiosource = go.AddComponent<AudioSource>();
        audiosource.clip = clip;
        audiosource.Play();

        Destroy(go, clip.length);
    }

    public void BgSoundPlay(AudioClip clip)
    {
        bgsound.clip = clip;
        bgsound.loop = true;
        bgsound.volume = 0.1f;
        bgsound.Play();

    }
    //사운드버튼 on/off
    public void OnbuttonPress()
    {
        if (muted == false)
        {
            muted = true;
            AudioListener.pause = true;
        }
        else
        {
            muted = false;
            AudioListener.pause = false;
        }

        //Save();
    }

    /*private void Load()
    {
        muted = PlayerPrefs.GetInt("muted") == 1;
    }

    private void Save()
    {
        PlayerPrefs.SetInt("muted", muted ? 1:0);
    }
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("muted"))
        {
            PlayerPrefs.SetInt("muted", 0);
            Load();
        }
        else
        {
            Load();
        }
        AudioListener.pause = muted;
    }*/

    // Update is called once per frame
    void Update()
    {
        
    }
}
