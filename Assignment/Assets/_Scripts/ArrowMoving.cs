using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMoving : MonoBehaviour
{
    public float speed = 10;
    public bool tfFlying = true;
    public bool tfMouseSetting = true;
    public bool tfReset = false;

    private MouseManager theMouse;
    private Quaternion originalRotation;
    private Vector3 originalPosition;
    // Start is called before the first frame update
    void Start()
    {
        originalRotation = gameObject.transform.rotation;
        originalPosition = gameObject.transform.position;
        theMouse = GameObject.Find("MouseManager").GetComponent<MouseManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (tfMouseSetting)
        {
            Vector3 mousePosition = theMouse.GetMousePosition();
            gameObject.transform.LookAt(mousePosition);
            gameObject.transform.eulerAngles = new Vector3(0, gameObject.transform.eulerAngles.y + 180.0f, 0);

            speed = Vector3.Distance(mousePosition, gameObject.transform.position) * 1.0f;
            if (Input.GetMouseButtonDown(1))
            {
                tfFlying = true;
                tfMouseSetting = false;
            }
        }

        if (tfFlying)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, (gameObject.transform.position + gameObject.transform.forward), speed * Time.deltaTime);
        }
        if (tfReset)
        {
            gameObject.transform.rotation = originalRotation;
            gameObject.transform.position = originalPosition;
            tfReset = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "BounceBoard")
        {
            float difference = gameObject.transform.eulerAngles.y - other.transform.eulerAngles.y;
            gameObject.transform.eulerAngles = new Vector3(0, other.transform.eulerAngles.y + 180.0f - difference, 0);
        }
    }
}
