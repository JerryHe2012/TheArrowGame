using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowHeadControl : MonoBehaviour
{
    public ArrowMoving theArrowHolder;

    [SerializeField]
    private float physicalCalculateError = 0.25f;
    [SerializeField]
    private float timeCounter = 0;

    private bool hit = false;
    private bool canhit = true;
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
        if (other.tag == "BounceBoard" || other.tag == "BounceGlass" || other.tag == "BounceItem")
        {
            canhit = false;
        }
        else
        {
            if ((other.gameObject.tag == "Target" || other.gameObject.tag == "WoodWall") && !theArrowHolder.tfWillBounce && theArrowHolder.tfFlying && canhit)
            {
                theArrowHolder.tfFlying = false;
                GameObject.Find("EffectAudio").GetComponent<AudioControl>().PlayHit();
                theArrowHolder.gameObject.transform.parent = other.gameObject.transform.parent;
                if (other.gameObject.tag == "Target")
                {
                    GameObject.Find("ScoreSystem").GetComponent<ScoreSystem>().AddScore();
                    GameObject.Find("GeneralManager").GetComponent<LevelManager>().tfPause = true;
                    GameObject.Find("Message").GetComponent<ErrorMessage>().displayHitTarget();
                    hit = true;
                }
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "BounceBoard" || other.tag == "BounceGlass" || other.tag == "BounceItem")
        {
            canhit = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "BounceBoard" || other.tag == "BounceGlass" || other.tag == "BounceItem")
        {
            canhit = true;
        }
    }
}
