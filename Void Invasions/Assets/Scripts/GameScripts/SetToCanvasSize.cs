using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetToCanvasSize : MonoBehaviour
{
    public GameObject canvasObj;
    float xw;
    float xe;
    float yn;
    float ys;
    float width;
    float height;
    RectTransform rt;
    
    private void Awake()
    {
        rt = canvasObj.GetComponent<RectTransform>();

        width = rt.sizeDelta.x;
        height = rt.sizeDelta.y;


    }
}
