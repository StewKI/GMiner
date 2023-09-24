using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{

    public GameObject generator;
    private ProceduralGeneration pGen;

    public float drillSpeed = 1f;
    public float laziness = 0.1f;

    private float actualSpeed = 0f;

    private const float HeightBG = 13.96f;
    private float dokleDoso = -HeightBG / 2; //TODO : rename
    private int numOfSpawnedBGs = 0;
    private bool started = false;
    private bool isSlowMode = false;
    private bool isPaused = true;

    private bool gameStarted = false;
    private float timeElapsed = 0f;
    private float simTime = 30f;

    // Start is called before the first frame update
    void Start()
    {
        pGen = generator.GetComponent<ProceduralGeneration>();
        //pGen.Generate()
    }

    public void SlowMode(bool activated)
    {
        isSlowMode = activated;
    }

    private float DrillSpeed()
    {
        if (isPaused) return 0f;

        float ds = drillSpeed;
        if (isSlowMode)
        {
            ds *= 0.7f;
        }
        return ds;
    }

    public void GamePause(bool paused)
    {
        isPaused = paused;
        GetComponentInChildren<PlayerController>().GamePause(paused);

        if (!gameStarted)
        {
            gameStarted = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(actualSpeed > DrillSpeed()) actualSpeed = DrillSpeed();

        if ((Input.touchCount > 0 || Input.GetMouseButton(0)) || actualSpeed < 0f)
        {
            if (actualSpeed < DrillSpeed())
                actualSpeed += laziness;
        }
        else
        {
            if (actualSpeed > 0f)
                actualSpeed -= laziness;

            if (actualSpeed < laziness)
            {
                actualSpeed = 0f;
            }
        }

        transform.position = new Vector3(transform.position.x, transform.position.y - (actualSpeed * Time.fixedDeltaTime), transform.position.z);

        if (transform.position.y < dokleDoso)
        {
            dokleDoso -= HeightBG;
            numOfSpawnedBGs++;
            pGen.GenerateBG(HeightBG * (numOfSpawnedBGs + 0.5f));
            if (numOfSpawnedBGs % 2 == 0)
            {
                pGen.Generate(10, -numOfSpawnedBGs * HeightBG);
            }
            Debug.Log("uradio");
        }

        if (actualSpeed > 0f && !started)
        {
            GetComponentInChildren<PlayerController>().TurnParticles(true);
            GetComponentInChildren<TaleController>().CreateBrush();
            started = true;
        }
        else if (actualSpeed == 0f)
        {
            GetComponentInChildren<PlayerController>().TurnParticles(false);
            GetComponentInChildren<TaleController>().StopTale();
            started = false;
        }

        if (gameStarted)
        {
            timeElapsed += Time.deltaTime;
            if (timeElapsed > simTime)
            {
                EndScreen();
            }
        }
    }

    private void EndScreen()
    {
        SceneManager.LoadScene(1);
    }


    public void ReturnBack()
    {
        actualSpeed = -DrillSpeed();
    }
}
