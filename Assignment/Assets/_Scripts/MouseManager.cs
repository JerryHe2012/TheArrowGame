using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    public bool tfHolding = false;
    public GameObject holdingObj = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 GetMousePosition()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.y - gameObject.transform.position.y);
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        return mousePosition;
    }
}
