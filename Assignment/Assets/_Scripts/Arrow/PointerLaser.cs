using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerLaser : MonoBehaviour
{
    [SerializeField]
    private GameObject glowingPoint = null;

    private LineRenderer lr = null;

    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameObject.transform.parent.gameObject.GetComponent<ArrowMoving>().tfMouseSetting)
        {
            lr.enabled = false;
            glowingPoint.SetActive(false);
        }
        else
        {
            lr.enabled = true;
            glowingPoint.SetActive(true);
        }

        lr.SetPosition(0, transform.position);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Wall"))
            {
                lr.SetPosition(1, hit.point - (transform.forward * 0.2f));
                glowingPoint.transform.position = hit.point;
            }
            else
            {
                lr.SetPosition(1, glowingPoint.transform.position - (transform.forward * 0.2f));
            }
        }
        else
        {
            lr.SetPosition(1, transform.forward * 500);
        }
    }
}
