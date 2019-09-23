using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMoving : MonoBehaviour
{
    float speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, (gameObject.transform.position + gameObject.transform.forward), speed * Time.deltaTime);
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
