using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public bool tfTutorialOn = true;
    public bool tfPause = false;

    [SerializeField]
    private GameObject Menu = null;

    private GameObject theTutoial = null;
    // Start is called before the first frame update
    void Start()
    {
        theTutoial = GameObject.Find("Tutorial");
    }

    // Update is called once per frame
    void Update()
    {
        if (tfTutorialOn)
        {
            tfPause = true;
            GameObject.Find("ArrowSpawn").GetComponent<ArrowSpawning>().previousObject.GetComponent<ArrowMoving>().tfMouseSetting = false;
            if (!theTutoial.activeSelf)
            {
                theTutoial.SetActive(true);                
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                tfTutorialOn = false;
                tfPause = false;
                theTutoial.SetActive(false);
                GameObject.Find("ArrowSpawn").GetComponent<ArrowSpawning>().previousObject.GetComponent<ArrowMoving>().tfMouseSetting = true;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (Menu.activeSelf)
                {
                    ResumeGame();
                }
                else
                {
                    Menu.SetActive(true);
                    tfPause = true;
                    GameObject.Find("ArrowSpawn").GetComponent<ArrowSpawning>().previousObject.GetComponent<ArrowMoving>().tfMouseSetting = false;
                }
            }
        }
    }

    public void OpenTutorial()
    {
        if (!tfPause)
        {
            tfTutorialOn = true;
        }
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void ResumeGame()
    {
        Menu.SetActive(false);
        tfPause = false;
        GameObject.Find("ArrowSpawn").GetComponent<ArrowSpawning>().previousObject.GetComponent<ArrowMoving>().tfMouseSetting = true;
        EventSystem.current.SetSelectedGameObject(null);
    }
}