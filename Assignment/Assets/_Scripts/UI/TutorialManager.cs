using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;

public class TutorialManager : MonoBehaviour
{

    [SerializeField]
    private GameObject tutorialManager = null;

    [SerializeField]
    private GameObject tileRotation = null;

    private bool disableShoot1 = true;
    private bool disableShoot2 = false;
    private bool isOnFreeRotation = false;

    private bool firstStepDone = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(disableShoot1)
        {
            GameObject.Find("ArrowHolder").GetComponent<ArrowMoving>().tfMouseSetting = false;
            Invoke("enableArrow", 4);
        }
        if (Input.GetMouseButtonDown(1) && !firstStepDone && !disableShoot1)
        {
            tutorialManager.SetActive(true);
            GameObject.Find("MoveBowText (TMP)").GetComponent<TextMeshProUGUI>().text = "Nice, now lets try using some tiles!";
            GameObject.Find("MoveBowText (TMP)").GetComponent<TextMeshProUGUI>().alpha = 255;
            GameObject.Find("MoveBowMessage").GetComponent<Animation>().Play();
            Invoke("RespawnTile", 2);
            GameObject.Find("ArrowHolder").GetComponent<ArrowMoving>().tfMouseSetting = false;
            firstStepDone = true;
        }

        //need to fix the condition on this if
        if(isOnFreeRotation && Input.GetMouseButtonDown(0))
        {

            Debug.Log("loooooooooooooool");
            GameObject.Find("ArrowHolder").GetComponent<ArrowMoving>().tfMouseSetting = true;
            GameObject.Find("MoveBowText (TMP)").GetComponent<TextMeshProUGUI>().text = "Great, now get a new arrow by pressing the 'w' key";
            GameObject.Find("MoveBowText (TMP)").GetComponent<TextMeshProUGUI>().alpha = 255;
            GameObject.Find("MoveBowMessage").GetComponent<Animation>().Play();
            disableShoot2 = true;


            isOnFreeRotation = false;
        }

        //this seems kinda buggy
        if(!disableShoot2)
        {
            GameObject.Find("ArrowHolder").GetComponent<ArrowMoving>().tfMouseSetting = false;
        }

    }

    void enableArrow()
    {
        GameObject.Find("ArrowHolder").GetComponent<ArrowMoving>().tfMouseSetting = true;
        disableShoot1 = false;
    }


    void RespawnTile()
    {
        GameObject.Find("ItemHolder").transform.localScale = new Vector3(1, 1, 1);
        tileRotation.SetActive(true);
        GameObject.Find("TutorialInstructionsText").GetComponent<TextMeshProUGUI>().text = "1. Pick up a tile using left mouse button\n2. rotate the tile using 'q'and 'e' keys\n3. Change rotation settings to 'free rotation'";
    }


    public void OnFreeRotationClick()
    {
        Debug.Log("YOOOOOOOOOOOOOOOOOOO");
        isOnFreeRotation = true;
    }


}