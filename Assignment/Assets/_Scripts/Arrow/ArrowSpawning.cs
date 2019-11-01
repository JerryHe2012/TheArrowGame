using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ArrowSpawning : MonoBehaviour
{
    public GameObject previousObject = null;

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
    }

    // Update is called once per frame
    void Update()
    {
        if (!previousObject.GetComponent<ArrowMoving>().tfMouseSetting)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                if (totalArrowCount < stageArrowLimit)
                {
                    previousObject = GameObject.Instantiate(thePreFab, gameObject.transform);
                }
                else
                {
                    GameObject.Find("Message").GetComponent<ErrorMessage>().displayArrowError();
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void updateArrowCount()
    {
        totalArrowCount++;
        GameObject.Find("ArrowText").GetComponent<TextMeshProUGUI>().text = "Arrow: " + totalArrowCount + "/" + stageArrowLimit;
    }
}
