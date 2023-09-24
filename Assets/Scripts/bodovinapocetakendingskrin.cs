using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bodovinapocetakendingskrin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TMP_Text>().text = MainMenuController.bodovi.ToString();
    }

    public void OdustaniBtn()
    {
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
