using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIdisable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("GameMode").GetComponent<GameMode>().mode != GameMode.GameType.Practice)
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
