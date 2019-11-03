using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassAction : MonoBehaviour
{    
    public Rigidbody[] allRig;

    private List<Vector3> allOriginalPosition = new List<Vector3>();
    private List<Quaternion> allOriginalRotation = new List<Quaternion>();
    // Start is called before the first frame update
    void Start()
    {
        foreach (Rigidbody rb in allRig)
        {
            allOriginalPosition.Add(rb.position);
            allOriginalRotation.Add(rb.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangePhysic()
    {
        allOriginalPosition.Clear();
        allOriginalRotation.Clear();
        foreach (Rigidbody rb in allRig)
        {
            allOriginalPosition.Add(rb.position);
            allOriginalRotation.Add(rb.rotation);
            rb.isKinematic = false;
        }
    }

    public void ReversePosition()
    {
        int i = 0;
        gameObject.GetComponent<BoxCollider>().enabled = true;
        foreach (Rigidbody rb in allRig)
        {
            rb.isKinematic = true;
            rb.position = allOriginalPosition[i];
            rb.rotation = allOriginalRotation[i];
            i++;
        }
    }
}
