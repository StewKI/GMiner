using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpAnim : MonoBehaviour
{
    public float fNormalScale = 1f;
    public float fBiggerScale = 1.2f;
    public float fSmallerScale = 0.2f;

    private Vector3 normalScale = new Vector3(0.25f, 0.25f);
    private Vector3 biggerScale = new Vector3(0.3f, 0.3f);
    private Vector3 smallerScale = new Vector3(0.05f, 0.05f);

    public float animationSpeed = 1f;
    public float luft = 0.1f;

    private int state = 0;


    // Start is called before the first frame update
    void Start()
    {
        normalScale = new Vector3(fNormalScale, fNormalScale);
        biggerScale = new Vector3(fBiggerScale, fBiggerScale);
        smallerScale = new Vector3(fSmallerScale, fSmallerScale);
        transform.localScale = smallerScale;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case 0:
                transform.localScale = Vector2.Lerp(transform.localScale, biggerScale, animationSpeed * Time.deltaTime);
                break;

            case 1:
                transform.localScale = Vector2.Lerp(transform.localScale, normalScale, animationSpeed * Time.deltaTime);
                break;

        }

        if (Vector3.Distance(transform.localScale, biggerScale) < luft) state = 1;
        else if (transform.localScale == normalScale) state = 2;
    }
}