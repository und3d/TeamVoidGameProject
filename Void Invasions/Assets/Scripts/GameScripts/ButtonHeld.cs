using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHeld : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Button is being pressed");
        HighScoreManager.Instance.buttonPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("Button is no longer being pressed");
        HighScoreManager.Instance.buttonPressed = false;
    }
}
