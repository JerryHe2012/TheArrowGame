using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErrorMessage : MonoBehaviour
{
    [SerializeField]
    GameObject ArrowError = null;
    [SerializeField]
    GameObject IronPlateError = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void displayArrowError()
    {
        ArrowError.SetActive(true);
        IronPlateError.SetActive(false);
        gameObject.GetComponent<Animation>().Play();
    }

    public void displayIronPlateError()
    {
        ArrowError.SetActive(false);
        IronPlateError.SetActive(true);
        gameObject.GetComponent<Animation>().Play();
    }
}
