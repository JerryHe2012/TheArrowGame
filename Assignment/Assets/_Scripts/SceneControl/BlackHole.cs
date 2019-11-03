using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    [SerializeField]
    private float effectRadius = 10.0f;
    [SerializeField]
    private float rotateSpeed = 20.0f;

    private GameObject theArrow;
    // Start is called before the first frame update
    void Start()
    {
        theArrow = GameObject.Find("ArrowSpawn").GetComponent<ArrowSpawning>().previousObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (theArrow != GameObject.Find("ArrowSpawn").GetComponent<ArrowSpawning>().previousObject)
        {
            theArrow = GameObject.Find("ArrowSpawn").GetComponent<ArrowSpawning>().previousObject;
        }

        if (theArrow.GetComponent<ArrowMoving>().tfFlying)
        {
            float theDistance = Vector3.Distance(theArrow.transform.position, gameObject.transform.position);
            if (theDistance < effectRadius)
            {
                theArrow.transform.Find("RotationHolder").LookAt(gameObject.transform);
                theArrow.transform.rotation = Quaternion.RotateTowards(theArrow.transform.rotation, theArrow.transform.Find("RotationHolder").rotation, rotateSpeed * (theDistance / effectRadius));
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawLine(
            Vector3.zero,
            Vector3.up
        );

        Gizmos.DrawWireSphere(gameObject.transform.position, effectRadius);

        Gizmos.color = Color.white;
    }
}
