using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public bool tfTutorialOn = true;
    public bool tfPause = false;

    [SerializeField]
    private GameObject Menu = null;
    [SerializeField]
    private GameObject WinMenu = null;
    [SerializeField]
    private GameObject theTutoial = null;
    [SerializeField]
    private string nextLevel = "Level2";

    // Start is called before the first frame update
    void Start()
    {
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

    public void CloseTutorial()
    {
        tfTutorialOn = false;
        tfPause = false;
        theTutoial.SetActive(false);
        GameObject.Find("ArrowSpawn").GetComponent<ArrowSpawning>().previousObject.GetComponent<ArrowMoving>().tfMouseSetting = true;
    }

    public void WinOption()
    {
        GameObject.Find("ArrowSpawn").GetComponent<ArrowSpawning>().previousObject.GetComponent<ArrowMoving>().tfMouseSetting = false;
        WinMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        Menu.SetActive(false);
        WinMenu.SetActive(false);
        tfPause = false;
        GameObject.Find("ArrowSpawn").GetComponent<ArrowSpawning>().previousObject.GetComponent<ArrowMoving>().tfMouseSetting = true;
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void ProcessToNextLevel()
    {
        SceneManager.LoadScene(nextLevel);
    }

    public void RestartLevel()
    {
        GameObject.Find("ScoreSystem").GetComponent<ScoreSystem>().RemoveScore();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void ShowMessageAnimation()
    {
        //GameObject.Find("MoveBowMessage").GetComponent<HideLevelLoading>().enabled = true;
        GameObject.Find("MoveBowText (TMP)").GetComponent<TextMeshProUGUI>().alpha = 255;
        GameObject.Find("MoveBowMessage").GetComponent<Animation>().Play();
        GameObject.Find("MoveBowMessage").GetComponent<TutorialMessages>().tfLoadingMessage = true;
        GameObject.Find("TutorialInstructionsText").GetComponent<TextMeshProUGUI>().alpha = 255;
    }


}