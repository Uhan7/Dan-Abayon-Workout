using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseDetector : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public static bool mouseDetected;

    void Start()
    {
        mouseDetected = true;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        mouseDetected = false;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouseDetected = true;
    }

}
