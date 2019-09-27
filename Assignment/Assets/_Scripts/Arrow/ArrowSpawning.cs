using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawning : MonoBehaviour
{
    public GameObject previousObject = null;

    [SerializeField]
    private GameObject thePreFab = null;

    // Start is called before the first frame update
    void Start()
    {
        previousObject = GameObject.Find("ArrowHolder");
    }

    // Update is called once per frame
    void Update()
    {
        if (!previousObject.GetComponent<ArrowMoving>().tfMouseSetting)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                previousObject = GameObject.Instantiate(thePreFab, gameObject.transform);
            }
        }
    }
}
