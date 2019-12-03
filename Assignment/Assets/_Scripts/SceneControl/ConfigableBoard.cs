using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ConfigableBoard : MonoBehaviour
{
    public bool tfRotateByAngle = true;
    public float rotateAngle = 45.0f;
    public float rotateSpeed = 100.0f;
    public int boardLimit = 2;
    public int boardcount = 0;

    [SerializeField]
    private GameObject referText = null;
    [SerializeField]
    private string theText = "Iron Plate:";
    [SerializeField]
    private bool tfMovable = true;
    [SerializeField]
    private bool tfGlass = false;
    [SerializeField]
    private AnimationClip theClip = null;

    private MouseManager theMouse;
    private bool tfFirstGrab = true;
    private Vector3 moveOffset = Vector3.zero;

    private Vector3 rememberPosition = new Vector3();
    private Vector3 rememberRotation = new Vector3();
    private bool tfColliding = false;
    // Start is called before the first frame update
    void Start()
    {
        theMouse = GameObject.Find("MouseManager").GetComponent<MouseManager>();
        if (tfGlass)
        {
            GameObject.Find("ArrowSpawn").GetComponent<ArrowSpawning>().allGlassBoard.Add(gameObject.GetComponent<GlassAction>());
        }
        if (tfMovable)
        {
            referText.GetComponent<TextMeshProUGUI>().text = theText + boardcount + "/" + boardLimit;
        }
        if (tfMovable)
        {
            if (tfGlass)
            {
                GameObject.Find("ScoreSystem").GetComponent<ScoreSystem>().glassLeft = boardLimit - boardcount;
            }
            else
            {
                GameObject.Find("ScoreSystem").GetComponent<ScoreSystem>().ironLeft = boardLimit - boardcount;
            }
        }

        rememberPosition = gameObject.transform.position;
        rememberRotation = new Vector3(0, gameObject.transform.eulerAngles.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (!theMouse.tfHolding && tfMovable && !tfColliding)
        {
            if (gameObject.transform.position != rememberPosition)
            {
                rememberPosition = gameObject.transform.position;
                rememberRotation = new Vector3(0, gameObject.transform.eulerAngles.y, 0);
            }
        }
    }

    private void OnMouseDown()
    {
        if (!GameObject.Find("GeneralManager").GetComponent<LevelManager>().tfPause && tfMovable)
        {
            if (!theMouse.tfHolding)
            {
                theMouse.tfHolding = true;
                theMouse.holdingObj = gameObject;
                if (tfFirstGrab)
                {
                    updateBoardCount();
                    if (boardcount < boardLimit)
                    {
                        GameObject newBoard = GameObject.Instantiate(gameObject);
                        newBoard.transform.position = gameObject.transform.position;
                        newBoard.transform.rotation = gameObject.transform.rotation;
                    }                    
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
    }

    private void OnMouseUp()
    {
        if (!GameObject.Find("GeneralManager").GetComponent<LevelManager>().tfPause && tfMovable)
        {
            if (theMouse.tfHolding)
            {
                theMouse.tfHolding = false;
                if (tfGlass)
                {
                    gameObject.GetComponent<GlassAction>().ReGainPosition();
                }                
            }
        }
    }

    private void OnMouseDrag()
    {
        if (!GameObject.Find("GeneralManager").GetComponent<LevelManager>().tfPause && tfMovable)
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

    public void updateBoardCount()
    {
        boardcount++;
        referText.GetComponent<TextMeshProUGUI>().text = theText + boardcount  + "/" + boardLimit;
        if (tfGlass)
        {
            GameObject.Find("ScoreSystem").GetComponent<ScoreSystem>().glassLeft = boardLimit - boardcount;
        }
        else
        {
            GameObject.Find("ScoreSystem").GetComponent<ScoreSystem>().ironLeft = boardLimit - boardcount;
        }        
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.tag == "BounceBoard" || other.tag == "BounceGlass"))
        {
            tfColliding = true;
        }        
    }

    private void OnTriggerStay(Collider other)
    {
        if ((other.tag == "BounceBoard" || other.tag == "BounceGlass"))
        {
            if (!theMouse.tfHolding && tfMovable)
            {
                if (gameObject.transform.position != rememberPosition)
                {
                    gameObject.transform.position = rememberPosition;
                    gameObject.transform.eulerAngles = rememberRotation;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if ((other.tag == "BounceBoard" || other.tag == "BounceGlass"))
        {
            tfColliding = false;
        }
    }

    public void PlayAnimation()
    {
        gameObject.GetComponent<Animation>().clip = theClip;
        gameObject.GetComponent<Animation>().Play();     
    }
}
