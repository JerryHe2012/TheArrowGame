using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMessages : MonoBehaviour
{
    public bool tfLoadingMessage = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(tfLoadingMessage && !gameObject.GetComponent<Animation>().isPlaying)
        {
            gameObject.transform.parent.gameObject.SetActive(false);
        }
    }
}
