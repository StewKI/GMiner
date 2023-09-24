using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    public Camera cam;
    public GameObject sprite;

    public GameObject generatorObj;
    private ProceduralGeneration pGen;

    public float velocity = 1f;
    public float laziness = 0.1f;
    public float rotationScale = 1f;

    private bool isPaused = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        pGen = generatorObj.GetComponent<ProceduralGeneration>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isPaused)
        {
            rb.velocity = Vector2.MoveTowards(rb.velocity, new Vector2(Movement() * velocity, 0f), laziness * Time.fixedDeltaTime);

            float rotZ = rotationScale * Vector2.Angle(Vector2.down, new Vector2(rb.velocity.x, -1f));

            rotZ = Mathf.Exp(rotZ);

            if (Vector2.SignedAngle(Vector2.down, new Vector2(rb.velocity.x, -1f)) < 0f)
            {
                rotZ *= -1;
            }

            sprite.transform.rotation = Quaternion.Euler(0, 0, rotZ);
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
        }

    }

    public void GamePause(bool paused)
    {
        isPaused = paused;
    }

    public void TurnParticles(bool On)
    {
        if (On)
        {
            sprite.GetComponentInChildren<ParticleSystem>().Play();
        }
        else
        {
            sprite.GetComponentInChildren<ParticleSystem>().Stop();
        }
    }

    private int Movement()  // (-1 = left), (1 = right)
    {
        const float luft = 0.2f;

        if (Input.touchCount > 0)
        {
            var tInput = Input.GetTouch(0);
            float xTouch = cam.ScreenToWorldPoint(tInput.position).x;

            //Debug.Log(xTouch);

            float xDrill = transform.position.x;
            if (Mathf.Abs(xTouch - xDrill) > luft)
            {
                if (xTouch > xDrill)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
        }

        if(Input.GetMouseButton(0))
        {
            float xClick = cam.ScreenToWorldPoint(Input.mousePosition).x;
            float xDrill = transform.position.x;
            if (Mathf.Abs(xClick - xDrill) > luft)
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "kamen")
        {
            cam.GetComponent<CameraController>().ReturnBack();
        }
        else if (collision.gameObject.tag == "nafta")
        {
            pGen.GeneratePipesAsync(collision.gameObject.transform.position);
            pGen.GenerateStar(MainMenuController.typeOfUser, collision.gameObject.transform.position);
            cam.GetComponent<CameraController>().SlowMode(true);
            MainMenuController.bodovi += MainMenuController.typeOfUser + 1;
            //Nafta();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "nafta")
        {
            cam.GetComponent<CameraController>().SlowMode(false);
            //Nafta();
        }
    }

    private void Nafta()
    {

    }

}
