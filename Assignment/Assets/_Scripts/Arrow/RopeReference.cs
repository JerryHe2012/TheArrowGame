using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeReference : MonoBehaviour
{
    public GameObject theArrowTail = null;

    [SerializeField]
    public GameObject theRopeHeadOne = null;
    [SerializeField]
    public GameObject theRopeHeadTwo = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateRopePosition()
    {
        gameObject.GetComponent<LineRenderer>().SetPosition(0, theRopeHeadOne.transform.position);
        gameObject.GetComponent<LineRenderer>().SetPosition(1, theArrowTail.transform.position);
        gameObject.GetComponent<LineRenderer>().SetPosition(2, theRopeHeadTwo.transform.position);
    }
}
