using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Functions : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] GameObject mainText;
    [SerializeField] TMP_Text btnText;
    public float animationSpeed = 10f;

    private const float lowPosY = -220f;
    private const float highPosY = 400f;

    private float wantedPosY = highPosY;

    private RectTransform rectTrans;

    public void openHidePanel()
    {

        Debug.Log("uso");
        if(rectTrans.anchoredPosition.y > 0)
        {
            btnText.text = "PREKINI IGRU";
            wantedPosY = lowPosY;
            //rectTrans.anchoredPosition = new Vector2(rectTrans.anchoredPosition.x, -220f);
        }
        else
        {
            btnText.text = "NASTAVI IGRU";
            wantedPosY = highPosY;
            //rectTrans.anchoredPosition = new Vector2(rectTrans.anchoredPosition.x, 400f);
        }


        if (mainText != null)
        {
            bool isTextActive = mainText.activeSelf;

            mainText.SetActive(!isTextActive);
        }
           
    }

    private void Start()
    {
        rectTrans = panel.GetComponent<RectTransform>();
    }

    private void LateUpdate()
    {
        rectTrans.anchoredPosition = Vector2.Lerp(rectTrans.anchoredPosition, new Vector2(rectTrans.anchoredPosition.x, wantedPosY), Time.deltaTime * animationSpeed);
    }

}
