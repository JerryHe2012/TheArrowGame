using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigableBoard : MonoBehaviour
{
    public bool tfRotateByAngle = true;
    public float rotateAngle = 45.0f;
    public float rotateSpeed = 100.0f;

    private MouseManager theMouse;
    private bool tfFirstGrab = true;
    private Vector3 moveOffset = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        theMouse = GameObject.Find("MouseManager").GetComponent<MouseManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (!theMouse.tfHolding)
        {
            theMouse.tfHolding = true;
            theMouse.holdingObj = gameObject;
            if (tfFirstGrab)
            {
                GameObject newBoard = GameObject.Instantiate(gameObject);
                newBoard.transform.position = gameObject.transform.position;
                newBoard.transform.rotation = gameObject.transform.rotation;
                gameObject.transform.rotation = Quaternion.identity;
                tfFirstGrab = false;
            }
            GameObject theButton = GameObject.Find("RotationButton");
            if (theButton.GetComponent<RotationButtonControl>().tfFixedRotation)
            {
                tfRotateByAngle = true;
            }
            else
            {
                tfRotateByAngle = false;
            }
            moveOffset = gameObject.transform.position - theMouse.GetMousePosition();
        }        
    }

    private void OnMouseUp()
    {
        if (theMouse.tfHolding)
        {
            theMouse.tfHolding = false;
        }
    }

    private void OnMouseDrag()
    {
        if (theMouse.tfHolding && gameObject == theMouse.holdingObj)
        {
            gameObject.transform.position = theMouse.GetMousePosition() + moveOffset;
            if (tfRotateByAngle)
            {
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    gameObject.transform.eulerAngles = new Vector3(0, gameObject.transform.eulerAngles.y - rotateAngle, 0);
                }
                else if (Input.GetKeyDown(KeyCode.E))
                {
                    gameObject.transform.eulerAngles = new Vector3(0, gameObject.transform.eulerAngles.y + rotateAngle, 0);
                }
            }
            else
            {
                if (Input.GetKey(KeyCode.Q))
                {
                    gameObject.transform.eulerAngles = new Vector3(0, gameObject.transform.eulerAngles.y - rotateSpeed * Time.deltaTime, 0);
                }
                else if (Input.GetKey(KeyCode.E))
                {
                    gameObject.transform.eulerAngles = new Vector3(0, gameObject.transform.eulerAngles.y + rotateSpeed * Time.deltaTime, 0);
                }
            }            
        }        
    }
}
