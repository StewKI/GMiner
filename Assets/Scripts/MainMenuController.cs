using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public static int typeOfUser = 0;
    public static bool isPostpaid = false;
    public static int bodovi = 0;

    public GameObject dp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SameFunc()
    {
        typeOfUser = dp.GetComponent<TMP_Dropdown>().value;
    }

    public void PrepaidBtn()
    {
        isPostpaid = false;
        SameFunc();
        SceneManager.LoadScene(1);
    }
    public void PostpaidBtn()
    {
        isPostpaid = true;
        SameFunc();
        SceneManager.LoadScene(1);

    }


}
