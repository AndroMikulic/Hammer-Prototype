using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CustomButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
	
	Color32 defaultColor = new Color32(255, 255, 255, 255);
	Color32 hoverColor = new Color32(255, 189, 189, 255);

    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<Text>().color = hoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponent<Text>().color = defaultColor;
    }
}
