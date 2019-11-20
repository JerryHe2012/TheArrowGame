using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLoadingArrow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GetComponent<Animation>().isPlaying)
        {
            transform.localPosition = new Vector3(Random.Range(-5.0f, 5.0f), -10.0f, Random.Range(-5.0f, 5.0f));
            transform.localEulerAngles = new Vector3(0, Random.Range(0.0f, 360.0f), 0);
            GetComponent<Animation>().Play();
        }
    }
}