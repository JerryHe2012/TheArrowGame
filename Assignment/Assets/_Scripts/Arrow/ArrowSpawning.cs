﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ArrowSpawning : MonoBehaviour
{
    public GameObject previousObject = null;
    public List<GlassAction> allGlassBoard = new List<GlassAction>();

    [SerializeField]
    private GameObject thePreFab = null;
    [SerializeField]
    private int totalArrowCount = 0;
    [SerializeField]
    private int stageArrowLimit = 6;

    // Start is called before the first frame update
    void Start()
    {
        previousObject = GameObject.Find("ArrowHolder");
        GameObject.Find("ArrowText").GetComponent<TextMeshProUGUI>().text = "Arrow: " + totalArrowCount + "/" + stageArrowLimit;
        GameObject.Find("ScoreSystem").GetComponent<ScoreSystem>().arrowLeft = stageArrowLimit - totalArrowCount;
    }

    // Update is called once per frame
    void Update()
    {
        if (!previousObject.GetComponent<ArrowMoving>().tfMouseSetting && !GameObject.Find("GeneralManager").GetComponent<LevelManager>().tfPause)
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
