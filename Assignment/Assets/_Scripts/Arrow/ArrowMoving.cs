using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMoving : MonoBehaviour
{
    public float speed = 10;
    public float minCheck = 0.25f;
    public bool tfFlying = true;
    public bool tfWillBounce = false;
    public bool tfMouseSetting = true;

    [SerializeField]
    private float speedScale = 10.0f;    

    private bool tfshot = false;    
    private GameObject preBouncePlate = null;
    private float preDistance = 0.0f;
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
        if (tfshot)
        {
            tfMouseSetting = false;
        }

        if (tfMouseSetting)
        {
            Vector3 mousePosition = theMouse.GetMousePosition();
            gameObject.transform.LookAt(mousePosition);
            gameObject.transform.eulerAngles = new Vector3(0, gameObject.transform.eulerAngles.y + 180.0f, 0);

            speed = Vector3.Distance(mousePosition, gameObject.transform.position) * speedScale;
            if (Input.GetMouseButtonDown(1))
            {
                tfshot = true;
                tfFlying = true;
                tfMouseSetting = false;
                GameObject.Find("EffectAudio").GetComponent<AudioControl>().PlayBow();
            }
        }
        else
        {
            if (gameObject == GameObject.Find("ArrowSpawn").GetComponent<ArrowSpawning>().previousObject)
            {
                if (Input.GetKeyDown(KeyCode.R))
                {
                    gameObject.transform.rotation = originalRotation;
                    gameObject.transform.position = originalPosition;
                    preBouncePlate = null;
                    tfWillBounce = false;
                    tfshot = false;
                    tfFlying = false;
                    tfMouseSetting = true;
                }
            }
        }

        if (tfFlying)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, (gameObject.transform.position + gameObject.transform.forward), speed * Time.deltaTime);
        }

        if (tfWillBounce)
        {
            float newDistance = Vector3.Distance(gameObject.transform.position, preBouncePlate.transform.position);
            if (newDistance >= preDistance || newDistance < minCheck)
            {
                float difference = gameObject.transform.eulerAngles.y - preBouncePlate.transform.eulerAngles.y;
                gameObject.transform.eulerAngles = new Vector3(0, preBouncePlate.transform.eulerAngles.y + 180.0f - difference, 0);
                GameObject.Find("EffectAudio").GetComponent<AudioControl>().PlayHitIron();
                tfWillBounce = false;
            }
            else
            {
                preDistance = newDistance;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "BounceBoard" && tfFlying)
        {
            if (other.gameObject != preBouncePlate)
            {
                tfWillBounce = true;
                preBouncePlate = other.gameObject;
                preDistance = Vector3.Distance(gameObject.transform.position, preBouncePlate.transform.position);
            }        
        }
    }
}
