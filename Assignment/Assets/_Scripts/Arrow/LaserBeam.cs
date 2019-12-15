using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam : MonoBehaviour
{
    private GameObject theLaser = null;

    // Start is called before the first frame update
    void Start()
    {
        theLaser = gameObject.transform.Find("theLaser").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Arrow")
        {
            if (!other.gameObject.GetComponent<ArrowMoving>().tfMouseSetting)
            {
                other.gameObject.SetActive(false);
                gameObject.transform.Find("particle").GetComponent<ParticleSystem>().Play();
            }
        }
    }

    public void turnLaserOff()
    {
        theLaser.SetActive(false);
        gameObject.GetComponent<BoxCollider>().enabled = false;
    }

    public void turnLaserOn()
    {
        theLaser.SetActive(true);
        gameObject.GetComponent<BoxCollider>().enabled = true;
    }
}
