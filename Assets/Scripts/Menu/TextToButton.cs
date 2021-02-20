using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TextToButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{

    public delegate void OnClick();
    public OnClick m_OnClick;

    public Color baseColor;
    public Color hoverColor;

    private Text text;

    void Start() {
        text = GetComponent<Text>();
        baseColor = text.color;
    }

    public void OnPointerEnter(PointerEventData eventData) {
        text.color = baseColor;
    }

    public void OnPointerExit(PointerEventData eventData) {
        text.color = baseColor;
    }

    public void OnPointerDown(PointerEventData eventData) {
        m_OnClick();
    }
}
