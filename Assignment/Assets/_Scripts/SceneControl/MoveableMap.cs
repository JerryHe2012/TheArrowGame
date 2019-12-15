using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableMap : MonoBehaviour
{
    public bool tfTriggered = false;

    [SerializeField]
    private bool tfTrigger = false;
    [SerializeField]
    private Vector3 targetPosition = new Vector3(0, 0, 0);
    [SerializeField]
    private float speed = 1;
    [SerializeField]
    private bool tfWait = false;
    [SerializeField]
    private bool tfWaiting = false;
    [SerializeField]
    private float waitingTime = 2;
    [SerializeField]
    private bool tfStartWaiting = false;
    [SerializeField]
    private float startWaitingTime = 2;
    [SerializeField]
    private bool tfReachWait = false;
    [SerializeField]
    private bool tfReachWaiting = false;
    [SerializeField]
    private float reachWaitingTime = 0;

    private Vector3 originalPosition;
    private bool tfMovingToward = true;
    private float timeCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = gameObject.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (tfTrigger)
        {
            if (tfTriggered)
            {
                gameObject.transform.localPosition = Vector3.MoveTowards(gameObject.transform.localPosition, targetPosition, Time.deltaTime * speed);
            }
        }
        else
        {
            if (tfWaiting)
            {
                timeCounter = timeCounter + Time.deltaTime;
                if (tfStartWaiting)
                {
                    if (timeCounter > startWaitingTime)
                    {
                        tfWaiting = false;
                        tfStartWaiting = false;
                        timeCounter = 0;
                    }
                }
                else if (tfReachWaiting)
                {
                    if (timeCounter > reachWaitingTime)
                    {
                        tfWaiting = false;
                        tfReachWaiting = false;
                        timeCounter = 0;
                    }
                }
                else if (timeCounter > waitingTime)
                {
                    tfWaiting = false;
                    timeCounter = 0;
                }
            }
            else
            {
                if (tfMovingToward)
                {
                    gameObject.transform.localPosition = Vector3.MoveTowards(gameObject.transform.localPosition, targetPosition, Time.deltaTime * speed);
                    if (Vector3.Distance(gameObject.transform.localPosition, targetPosition) < 0.01f)
                    {
                        tfMovingToward = false;
                        if (tfReachWait)
                        {
                            tfWaiting = true;
                            tfReachWaiting = true;
                        }
                    }
                }
                else
                {
                    gameObject.transform.localPosition = Vector3.MoveTowards(gameObject.transform.localPosition, originalPosition, Time.deltaTime * speed);
                    if (Vector3.Distance(gameObject.transform.localPosition, originalPosition) < 0.01f)
                    {
                        tfMovingToward = true;
                        if (tfWait)
                        {
                            tfWaiting = true;
                        }
                    }
                }
            }
        }
    }
}
