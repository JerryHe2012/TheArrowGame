using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErrorMessage : MonoBehaviour
{
    [SerializeField]
    GameObject ArrowError = null;
    [SerializeField]
    GameObject IronPlateError = null;
    [SerializeField]
    GameObject HitTarget = null;
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
        HitTarget.SetActive(false);
        gameObject.GetComponent<Animation>().Play();
    }

    public void displayIronPlateError()
    {
        ArrowError.SetActive(false);
        IronPlateError.SetActive(true);
        HitTarget.SetActive(false);
        gameObject.GetComponent<Animation>().Play();
    }

    public void displayHitTarget()
    {
        ArrowError.SetActive(false);
        IronPlateError.SetActive(false);
        HitTarget.SetActive(true);
        gameObject.GetComponent<Animation>().Play();
    }
}
