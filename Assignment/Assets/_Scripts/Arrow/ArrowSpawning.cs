using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ArrowSpawning : MonoBehaviour
{
    public bool tfCanSpawn = true;
    public GameObject previousObject = null;
    public List<GlassAction> allGlassBoard = new List<GlassAction>();

    [SerializeField]
    private ButtonTrigger[] Buttons = null;
    [SerializeField]
    private GameObject thePreFab = null;
    [SerializeField]
    private int totalArrowCount = 0;
    [SerializeField]
    private int stageArrowLimit = 6;
    [SerializeField]
    private int hardStageArrowLimit = 6;

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("GameMode").GetComponent<GameMode>().mode == GameMode.GameType.Hard)
        {
            stageArrowLimit = hardStageArrowLimit;
        }
        else if (GameObject.Find("GameMode").GetComponent<GameMode>().mode == GameMode.GameType.Practice)
        {
            stageArrowLimit = 99;
        }

        previousObject = GameObject.Find("ArrowHolder");
        GameObject.Find("ArrowText").GetComponent<TextMeshProUGUI>().text = "Arrow: " + totalArrowCount + "/" + stageArrowLimit;
        GameObject.Find("ScoreSystem").GetComponent<ScoreSystem>().arrowLeft = stageArrowLimit - totalArrowCount;
    }

    // Update is called once per frame
    void Update()
    {
        if (tfCanSpawn && !previousObject.GetComponent<ArrowMoving>().tfMouseSetting && previousObject.GetComponent<ArrowMoving>().tfshot && !GameObject.Find("GeneralManager").GetComponent<LevelManager>().tfPause)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                if (totalArrowCount < stageArrowLimit)
                {
                    GameObject.Find("ScoreSystem").GetComponent<ScoreSystem>().arrowLeft = stageArrowLimit - totalArrowCount;
                    previousObject = GameObject.Instantiate(thePreFab, gameObject.transform);
                    foreach (GlassAction theGlass in allGlassBoard)
                    {
                        theGlass.ReversePosition();
                    }
                    foreach (ButtonTrigger bt in Buttons)
                    {
                        bt.ChangeBack();
                    }
                }
                else
                {
                    GameObject.Find("Message").GetComponent<ErrorMessage>().displayArrowError();
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            GameObject.Find("ScoreSystem").GetComponent<ScoreSystem>().RemoveScore();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void updateArrowCount()
    {
        totalArrowCount++;
        GameObject.Find("ArrowText").GetComponent<TextMeshProUGUI>().text = "Arrow: " + totalArrowCount + "/" + stageArrowLimit;
    }
}
