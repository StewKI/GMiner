using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    public Camera cam;
    public GameObject sprite;

    public float velocity = 1f;
    public float laziness = 0.1f;
    public float rotationScale = 1f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(rb.velocity, new Vector2(Movement() * velocity, 0f)) > 0.1f)
        rb.velocity = Vector2.MoveTowards(rb.velocity, new Vector2(Movement() * velocity, 0f), laziness);

        sprite.transform.rotation = Quaternion.Euler(0, 0, rotationScale * Vector2.SignedAngle(Vector2.down, new Vector2(rb.velocity.x, -1f)));

        Debug.Log(Vector2.down);
        Debug.Log(new Vector2(rb.velocity.x, -1f));
        Debug.Log(Vector2.SignedAngle(Vector2.down, new Vector2(rb.velocity.x, -1f)));

    }

    private int Movement()  //-1 = left, 1 = right
    {
        //TODO: add touch input

        if(Input.GetMouseButton(0))
        {
            
            float xClick = cam.ScreenToWorldPoint(Input.mousePosition).x;
            float xDrill = transform.position.x;
            if (Mathf.Abs(xClick - xDrill) > 0.1f)
            {
                if (xClick > xDrill)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
        }

        return 0;
    }

}
