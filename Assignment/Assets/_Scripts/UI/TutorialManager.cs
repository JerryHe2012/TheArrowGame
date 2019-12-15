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

    private bool disableShoot = true;
    private bool isOnFreeRotation = false;

    private bool firstStepDone = false;
    private bool secondStepDone = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(disableShoot)
        {
            GameObject.Find("ArrowSpawn").GetComponent<ArrowSpawning>().tfCanSpawn = false;
            Invoke("enableArrow", 3);
        }
        if (Input.GetMouseButtonDown(1) && !firstStepDone && !disableShoot)
        {
            tutorialManager.SetActive(true);
            GameObject.Find("MoveBowText (TMP)").GetComponent<TextMeshProUGUI>().text = "Nice, now lets try using some tiles!";
            GameObject.Find("MoveBowText (TMP)").GetComponent<TextMeshProUGUI>().alpha = 255;
            GameObject.Find("MoveBowMessage").GetComponent<Animation>().Play();
            Invoke("RespawnTile", 3);
            GameObject.Find("ArrowSpawn").GetComponent<ArrowSpawning>().tfCanSpawn = false;
            firstStepDone = true;
        }

        //need to fix the condition on this if
        if(isOnFreeRotation && Input.GetMouseButtonDown(0))
        {

            tutorialManager.SetActive(true);
            GameObject.Find("ArrowSpawn").GetComponent<ArrowSpawning>().tfCanSpawn = true;
            GameObject.Find("MoveBowText (TMP)").GetComponent<TextMeshProUGUI>().text = "Great, now get a new arrow by pressing the 'w' key";
            GameObject.Find("MoveBowText (TMP)").GetComponent<TextMeshProUGUI>().alpha = 255;
            GameObject.Find("MoveBowMessage").GetComponent<Animation>().Play();
            GameObject.Find("TutorialInstructionsText").GetComponent<TextMeshProUGUI>().text = "1. Press the 'W' key to get a new arrow\n2. Aim arrow at the tile\n3. Hit the target!";
            isOnFreeRotation = false;
            secondStepDone = true;
        }
    }

    void enableArrow()
    {
        GameObject.Find("ArrowSpawn").GetComponent<ArrowSpawning>().tfCanSpawn = true;
        disableShoot = false;
    }


    void RespawnTile()
    {
        GameObject.Find("ItemHolder").transform.localScale = new Vector3(1, 1, 1);
        tileRotation.SetActive(true);
        GameObject.Find("TutorialInstructionsText").GetComponent<TextMeshProUGUI>().text = "1. Pick up a tile using left mouse button\n2. rotate the tile using 'q'and 'e' keys\n3. Change rotation settings to 'free rotation'";
    }


    public void OnFreeRotationClick()
    {
        if(!secondStepDone)
        {
            isOnFreeRotation = true;
        }
    }


}