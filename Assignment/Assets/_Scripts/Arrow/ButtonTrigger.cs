using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    [SerializeField]
    private MoveableMap triggerDoor = null;
    [SerializeField]
    private Material green = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Arrow")
        {
            Material[] mats = gameObject.GetComponent<MeshRenderer>().materials;
            mats[1] = green;
            gameObject.GetComponent<MeshRenderer>().materials = mats;
            triggerDoor.tfTriggered = true;
        }
    }
}
