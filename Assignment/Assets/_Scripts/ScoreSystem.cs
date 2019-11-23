using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    public GameObject TheScoreBoard = null;
    public GameObject TheNameInput = null;
    public TextMeshProUGUI UserName = null;
    public string playerName = "";
    public int playerScore = 0;
    public int arrowLeft = 0;
    public int ironLeft = 0;
    public int glassLeft = 0;
    public List<TextMeshProUGUI> names = new List<TextMeshProUGUI>();
    public List<TextMeshProUGUI> scores = new List<TextMeshProUGUI>();
    public List<string> recordeNames = new List<string>();
    public List<int> recordeScore = new List<int>();
    public bool tfCounted = false;

    [SerializeField]
    private bool tfFirstScreen = false;
    [SerializeField]
    private bool tfLoadRecord = false;
    [SerializeField]
    private TextMeshProUGUI scoreText = null;

    private bool tfExeOnce = true;

    void OnEnable()
    {
        if (!tfFirstScreen)
        {
            playerScore = PlayerPrefs.GetInt("currentScore");
        }

        if (tfLoadRecord)
        {
            int count = 0;
            while (count < 10)
            {
                count++;
                recordeNames.Add(PlayerPrefs.GetString("Player" + count.ToString() + "Name"));
                if (recordeNames[count - 1] == "")
                {
                    recordeNames[count - 1] = "-";
                }
                recordeScore.Add(PlayerPrefs.GetInt("Player" + count.ToString() + "Score"));
            }
        }
    }

    void Start()
    {
        scoreText.text = "Score:  " + (playerScore * 100).ToString();
    }

    void Update()
    {
        if (tfExeOnce)
        {
            tfExeOnce = false;
            if (tfLoadRecord)
            {
                TheNameInput.SetActive(true);
                GameObject.Find("GeneralManager").GetComponent<LevelManager>().tfPause = true;
                GameObject.Find("ArrowSpawn").GetComponent<ArrowSpawning>().previousObject.GetComponent<ArrowMoving>().tfMouseSetting = false;
            }
            else
            {
                CloseBoard();
                TheNameInput.SetActive(false);
            }
        }
    }

    void OnDisable()
    {
        PlayerPrefs.SetInt("currentScore", playerScore);

        if (tfLoadRecord)
        {
            int count = 0;
            foreach (string name in recordeNames)
            {
                count++;
                PlayerPrefs.SetString("Player" + count.ToString() + "Name", name);
                if (count == 10)
                {
                    break;
                }
            }
            count = 0;
            foreach (int score in recordeScore)
            {
                count++;
                PlayerPrefs.SetInt("Player" + count.ToString() + "Score", score);
                if (count == 10)
                {
                    break;
                }
            }
        }        
    }

    public void AddScore()
    {
        if (!tfCounted)
        {
            tfCounted = true;
            playerScore = playerScore + arrowLeft + ironLeft + glassLeft;
            scoreText.text = "Score:  " + (playerScore * 100).ToString();
        }
    }

    public void RemoveScore()
    {
        if (tfCounted)
        {
            playerScore = playerScore - arrowLeft - ironLeft - glassLeft;
        }        
    }

    public void UpdateBoard()
    {
        TheScoreBoard.SetActive(true);
        int count = 0;
        foreach (string name in recordeNames)
        {
            names[count].text = name;
            count++;
            if (count == 10)
            {
                break;
            }
        }
        count = 0;
        foreach (int score in recordeScore)
        {
            scores[count].text = (score * 100).ToString();
            count++;
            if (count == 10)
            {
                break;
            }
        }
    }

    public void CloseBoard()
    {
        TheScoreBoard.SetActive(false);
        GameObject.Find("GeneralManager").GetComponent<LevelManager>().tfPause = false;
        GameObject.Find("ArrowSpawn").GetComponent<ArrowSpawning>().previousObject.GetComponent<ArrowMoving>().tfMouseSetting = true;
    }

    public void UpdateLeaderBoard()
    {
        int count = 0;
        playerName = UserName.text;
        foreach (int score in recordeScore)
        {
            if (playerScore >= score)
            {
                break;
            }
            count++;
        }
        recordeScore.Insert(count, playerScore);
        recordeNames.Insert(count, playerName);
        TheNameInput.SetActive(false);
        UpdateBoard();
    }
}
