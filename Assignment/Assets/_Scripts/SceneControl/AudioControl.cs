using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControl : MonoBehaviour
{
    [SerializeField]
    private AudioClip BowSound = null;
    [SerializeField]
    private AudioClip ArrowHit = null;
    [SerializeField]
    private AudioClip IronHit = null;

    private AudioSource theSource = null;
    // Start is called before the first frame update
    void Start()
    {
        theSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayBow()
    {
        theSource.clip = BowSound;
        theSource.volume = 1.0f;
        theSource.Play();
    }

    public void PlayHit()
    {
        theSource.clip = ArrowHit;
        theSource.volume = 0.3f;
        theSource.Play();
    }

    public void PlayHitIron()
    {
        theSource.clip = IronHit;
        theSource.volume = 0.3f;
        theSource.Play();
    }
}
