using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Functions : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] GameObject mainText;
    public float moveSpeed = 10f;

    public void openHidePanel()
    {

        var rectTrans = panel.GetComponent<RectTransform>();
        Debug.Log("uso");
        if(rectTrans.anchoredPosition.y > 0)
        {
            rectTrans.anchoredPosition = new Vector2(rectTrans.anchoredPosition.x, -220f);
        }
        else
        {
            rectTrans.anchoredPosition = new Vector2(rectTrans.anchoredPosition.x, 400f);
        }


        if (mainText != null)
        {
            bool isTextActive = mainText.activeSelf;

            mainText.SetActive(!isTextActive);
        }
           
    }

}
