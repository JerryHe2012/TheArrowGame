using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowHeadControl : MonoBehaviour
{
    public ArrowMoving theArrowHolder;
    private bool hit = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hit)
        {
            if (!GameObject.Find("Message").GetComponent<Animation>().isPlaying)
            {
                GameObject.Find("GeneralManager").GetComponent<LevelManager>().WinOption();
                hit = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.tag == "Target" || other.gameObject.tag == "WoodWall") && !theArrowHolder.tfWillBounce)
        {
            theArrowHolder.tfFlying = false;
            GameObject.Find("EffectAudio").GetComponent<AudioControl>().PlayHit();
            if (other.gameObject.tag == "Target")
            {
                GameObject.Find("Message").GetComponent<ErrorMessage>().displayHitTarget();
                hit = true;
            }
        }
    }
}
