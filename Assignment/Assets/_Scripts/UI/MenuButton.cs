using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MenuButton : MonoBehaviour
{
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
        SceneManager.LoadScene("LevelOne");
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void QuitGame()
    {
        Application.Quit();
        EventSystem.current.SetSelectedGameObject(null);
    }
}
