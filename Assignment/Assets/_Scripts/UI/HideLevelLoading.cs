using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideLevelLoading : MonoBehaviour
{
    [SerializeField]
    bool tfTutorialOn = false;
    [SerializeField]
    LevelManager levelManager = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameObject.GetComponent<Animation>().isPlaying)
        {
            gameObject.SetActive(false);
            levelManager.tfTutorialOn = tfTutorialOn;
        }
    }
}
