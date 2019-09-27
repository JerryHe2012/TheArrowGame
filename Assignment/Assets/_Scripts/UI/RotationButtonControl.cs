using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RotationButtonControl : MonoBehaviour
{    
    public bool tfFixedRotation = true;

    [SerializeField]
    private TextMeshProUGUI theText = null;    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchRotation()
    {
        if (tfFixedRotation)
        {
            theText.text = "Free Rotation";
            tfFixedRotation = false;
        }
        else
        {
            theText.text = "Fixed Rotation";
            tfFixedRotation = true;
        }
    }
}
