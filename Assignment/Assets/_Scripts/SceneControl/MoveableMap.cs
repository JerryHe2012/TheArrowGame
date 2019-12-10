using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableMap : MonoBehaviour
{
    [SerializeField]
    private Vector3 targetPosition = new Vector3(0, 0, 0);
    [SerializeField]
    private float speed = 1;

    private Vector3 originalPosition;
    private bool tfMovingToward = true;

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = gameObject.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (tfMovingToward)
        {
            gameObject.transform.localPosition = Vector3.MoveTowards(gameObject.transform.localPosition, targetPosition, Time.deltaTime * speed);
            if (Vector3.Distance(gameObject.transform.localPosition, targetPosition) < 0.01f)
            {
                tfMovingToward = false;
            }
        }
        else
        {
            gameObject.transform.localPosition = Vector3.MoveTowards(gameObject.transform.localPosition, originalPosition, Time.deltaTime * speed);
            if (Vector3.Distance(gameObject.transform.localPosition, originalPosition) < 0.01f)
            {
                tfMovingToward = true;
            }
        }
    }
}
