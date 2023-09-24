using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class bodovinapocetakendingskrin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TMP_Text>().text = MainMenuController.bodovi.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
