using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    [SerializeField]
    private MoveableMap[] triggerDoor = null;
    [SerializeField]
    private LaserBeam[] disableLaser = null;
    [SerializeField]
    private Material green = null;
    [SerializeField]
    private Material red = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Arrow")
        {
            Material[] mats = gameObject.GetComponent<MeshRenderer>().materials;
            mats[1] = green;
            gameObject.GetComponent<MeshRenderer>().materials = mats;
            GameObject.Find("EffectAudio").GetComponent<AudioControl>().PlayHitButton();
            if (triggerDoor != null)
            {
                foreach (MoveableMap td in triggerDoor)
                {
                    td.tfTriggered = true;
                }
            }
            if (disableLaser != null)
            {
                foreach (LaserBeam lb in disableLaser)
                {
                    lb.turnLaserOff();
                }
            }
        }
    }

    public void ChangeBack()
    {
        Material[] mats = gameObject.GetComponent<MeshRenderer>().materials;
        mats[1] = red;
        gameObject.GetComponent<MeshRenderer>().materials = mats;
        if (triggerDoor != null)
        {
            foreach (MoveableMap td in triggerDoor)
            {
                td.MoveBack();
            }
        }
        if (disableLaser != null)
        {
            foreach (LaserBeam lb in disableLaser)
            {
                lb.turnLaserOn();
            }
        }
    }
}
