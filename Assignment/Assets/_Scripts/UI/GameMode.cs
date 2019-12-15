using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMode : MonoBehaviour
{
    public enum GameType
    {
        Practice,
        Easy,
        Hard
    }

    public GameType mode = GameType.Easy;
    public string memoryStage = "";

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("GameMode");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
