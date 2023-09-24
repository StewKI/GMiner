using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class ProceduralGeneration : MonoBehaviour
{

    //[SerializeField] int height;
    float width;
    [SerializeField] GameObject rock1, rock2, rock3, rock4, oil1;
    GameObject rock, oil;
    [SerializeField] Camera cam;
    [SerializeField] int probability;
    int ranType, curType;
    int counter = 0;
    [SerializeField] int heightRepetition = 3;
    [SerializeField] GameObject background;
    [SerializeField] GameObject pipe;
    public GameObject[] stars;
    public int delayTimeMs = 80;

    private bool canSpawnPipes = true;


    private const float pipeOffset = 1.14f;

    void Start()
    {
        Generate(10, 0f);
    }

    public void GenerateStar(int type, Vector2 worldCoords)
    {
        Debug.Log(stars[type]);

        float x = Random.Range(0.2f, 0.5f);
        float y = Random.Range(0.2f, 0.5f);

        if (Random.Range(0f, 2f) > 1f) x *= -1;
        if (Random.Range(0f, 2f) > 1f) y *= -1;

        Instantiate(stars[type], new Vector3(worldCoords.x + x, worldCoords.y + y, -0.3f), Quaternion.identity);
    }

    public async void GeneratePipesAsync(Vector2 worldCoordinates)
    {
        if (canSpawnPipes)
        {

            Vector3 worldCoords = new Vector3(worldCoordinates.x, worldCoordinates.y + pipeOffset * 0.5f, -0.2f);

            Instantiate(pipe, worldCoords, Quaternion.identity);
            await Task.Delay(1 * delayTimeMs);
            Instantiate(pipe, worldCoords + new Vector3(0, pipeOffset * 1), Quaternion.identity);
            await Task.Delay(1 * delayTimeMs);
            Instantiate(pipe, worldCoords + new Vector3(0, pipeOffset * 2), Quaternion.identity);
            await Task.Delay(1 * delayTimeMs);
            Instantiate(pipe, worldCoords + new Vector3(0, pipeOffset * 3), Quaternion.identity);
            await Task.Delay(1 * delayTimeMs);
            Instantiate(pipe, worldCoords + new Vector3(0, pipeOffset * 4), Quaternion.identity);
            await Task.Delay(1 * delayTimeMs);
            Instantiate(pipe, worldCoords + new Vector3(0, pipeOffset * 5), Quaternion.identity);
            await Task.Delay(1 * delayTimeMs);
            Instantiate(pipe, worldCoords + new Vector3(0, pipeOffset * 6), Quaternion.identity);
        }

        canSpawnPipes = false;
        /*
        Task.Delay(1 * delayTimeMs).ContinueWith(t => Instantiate(pipe, worldCoords + new Vector3(0, pipeOffset * 1), Quaternion.identity));
        Task.Delay(1 * delayTimeMs).ContinueWith(t => Instantiate(pipe, worldCoords + new Vector3(0, pipeOffset * 1), Quaternion.identity));
        Task.Delay(2 * delayTimeMs).ContinueWith(t => Instantiate(pipe, worldCoords + new Vector3(0, pipeOffset * 2), Quaternion.identity));
        Task.Delay(3 * delayTimeMs).ContinueWith(t => Instantiate(pipe, worldCoords + new Vector3(0, pipeOffset * 3), Quaternion.identity));
        Task.Delay(4 * delayTimeMs).ContinueWith(t => Instantiate(pipe, worldCoords + new Vector3(0, pipeOffset * 4), Quaternion.identity));
        Task.Delay(5 * delayTimeMs).ContinueWith(t => Instantiate(pipe, worldCoords + new Vector3(0, pipeOffset * 5), Quaternion.identity));
        Task.Delay(6 * delayTimeMs).ContinueWith(t => Instantiate(pipe, worldCoords + new Vector3(0, pipeOffset * 6), Quaternion.identity)););*/
    }

    public void GenerateBG(float yOffset)
    {
        Instantiate(background, new Vector3(0, -yOffset, 1f), Quaternion.identity);
        canSpawnPipes = true;
    }

    public void Generate(int numOfRocks, float yOffset){

        ranType = UnityEngine.Random.Range(1, 10);
        for (int i=1;i<numOfRocks;i++){
            width = cam.ViewportToWorldPoint(new Vector3(Random.Range(0.1f, 0.9f), 0, 0)).x;
            do {
                curType = Random.Range(1, 10);
            } while (curType == ranType);
            spawnObject(curType, i, yOffset);
            counter++;
            ranType = curType;
        }
    }

    void spawnObject(int type, int i, float yOffset)
    {
        if (counter >= probability + Random.Range(0, 2))
        {
            oil = oil1;
            Instantiate(oil, new Vector2(width, -i * heightRepetition + yOffset), Quaternion.identity);
            counter = 0;
        }
        else
        {
            if (type % 4 == 1)
            {
                rock = rock1;
            }
            else if (type % 4 == 2)
            {
                rock = rock2;
            }
            else if (type % 4 == 3)
            {
                rock = rock3;
            }
            else
            {
                rock = rock4;

            }
            Instantiate(rock, new Vector2(width, -i * heightRepetition + yOffset), Quaternion.identity);
        }

    }

    static class AsyncUtils
    {
    }
}
