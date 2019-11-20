using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class MainMenuTextColorChange : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField]
    private TextMeshProUGUI theText = null;
    [SerializeField]
    private Color enterColor = Color.blue;
    [SerializeField]
    private Color exitColor = Color.white;
    [SerializeField]
    private Color clickColor = Color.red;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        theText.color = enterColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        theText.color = exitColor;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        theText.color = clickColor;
    }
}
