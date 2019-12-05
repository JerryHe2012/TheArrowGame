using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundMusicScript : MonoBehaviour
{
    private static BackgroundMusicScript instance = null;

    [SerializeField]
    private AudioClip MenuBG = null;
    [SerializeField]
    private AudioClip firstBG = null;
    [SerializeField]
    private AudioClip secondBG = null;
    [SerializeField]
    private AudioClip thirdBG = null;

    [SerializeField]
    private string firstSceneName = "";
    [SerializeField]
    private string secondSceneName = "";
    [SerializeField]
    private string thirdSceneName = "";


    private AudioSource theAudioSource = null;
    private bool tfAudioChanged = false;
    public static BackgroundMusicScript Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        theAudioSource = gameObject.GetComponent<AudioSource>();
        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == firstSceneName)
        {
            if (!tfAudioChanged)
            {
                tfAudioChanged = true;
                theAudioSource.clip = firstBG;
                if (!theAudioSource.isPlaying)
                {
                    theAudioSource.Play();
                }
            }
        }
        else if(SceneManager.GetActiveScene().name == secondSceneName)
        {
            if (!tfAudioChanged)
            {
                tfAudioChanged = true;
                theAudioSource.clip = secondBG;
                if (!theAudioSource.isPlaying)
                {
                    theAudioSource.Play();
                }
            }
        }
        else if (SceneManager.GetActiveScene().name == thirdSceneName)
        {
            if (!tfAudioChanged)
            {
                tfAudioChanged = true;
                theAudioSource.clip = thirdBG;
                if (!theAudioSource.isPlaying)
                {
                    theAudioSource.Play();
                }
            }
        }
        else
        {
            tfAudioChanged = false;
        }
    }
}
