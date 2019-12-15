using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MenuButton : MonoBehaviour
{
    [SerializeField]
    private string startSceneName = null;
    [SerializeField]
    private GameObject EasyButton = null;
    [SerializeField]
    private GameObject HardButton = null;
    [SerializeField]
    private GameObject TutorialButton = null;
    [SerializeField]
    private GameObject PracticeButton = null;
    [SerializeField]
    private GameObject BackButton = null;
    [SerializeField]
    private GameObject StartButton = null;
    [SerializeField]
    private GameObject ContinueButton = null;
    [SerializeField]
    private GameObject QuitButton = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(startSceneName);
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void QuitGame()
    {
        Application.Quit();
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void SetEasy()
    {
        GameObject.Find("GameMode").GetComponent<GameMode>().mode = GameMode.GameType.Easy;
        StartGame();
    }

    public void SetHard()
    {
        GameObject.Find("GameMode").GetComponent<GameMode>().mode = GameMode.GameType.Hard;
        StartGame();
    }

    public void SetPractice()
    {
        GameObject.Find("GameMode").GetComponent<GameMode>().mode = GameMode.GameType.Practice;
        StartGame();
    }

    public void SetTutorial()
    {
        GameObject.Find("GameMode").GetComponent<GameMode>().mode = GameMode.GameType.Practice;
        SceneManager.LoadScene("Tutorial");
    }

    public void StartButtonOp()
    {
        StartButton.SetActive(false);
        QuitButton.SetActive(false);
        ContinueButton.SetActive(false);
        TutorialButton.SetActive(true);
        EasyButton.SetActive(true);
        HardButton.SetActive(true);
        PracticeButton.SetActive(true);
        BackButton.SetActive(true);
    }

    public void BackButtonOp()
    {
        StartButton.SetActive(true);
        QuitButton.SetActive(true);
        ContinueButton.SetActive(true);
        TutorialButton.SetActive(false);
        EasyButton.SetActive(false);
        HardButton.SetActive(false);
        PracticeButton.SetActive(false);
        BackButton.SetActive(false);
    }

    public void ContinueStage()
    {
        if (GameObject.Find("GameMode").GetComponent<GameMode>().memoryStage != "")
        {
            SceneManager.LoadScene(GameObject.Find("GameMode").GetComponent<GameMode>().memoryStage);
        }
    }
}
