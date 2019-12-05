using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopPreviousBackgroundMusic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        BackgroundMusicScript.Instance.gameObject.GetComponent<AudioSource>().Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
