using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    private Vector3 normalScale = new Vector3(0.25f, 0.25f);
    private Vector3 biggerScale = new Vector3(0.3f, 0.3f);
    private Vector3 smallerScale = new Vector3(0.05f, 0.05f);

    public float animationSpeed = 1f;
    public float luft = 0.1f;
    public float repeatTime = 1f;

    private float curTime = 0f;
    private int state = 0;


    // Start is called before the first frame update
    void Start()
    {
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

            case 2:
                //Debug.Log("PIPE REPEAT: " + curTime);
                curTime += Time.deltaTime;
                if(curTime> repeatTime)
                {
                    curTime = 0f;
                    state = 0;
                }
                break;

        }

        if (Vector3.Distance(transform.localScale, biggerScale) < luft) state = 1;
        else if (Vector3.Distance(transform.localScale, normalScale) < luft && state == 1)
        {
            state = 2;
            biggerScale.y = normalScale.y;
        }


    }
}
