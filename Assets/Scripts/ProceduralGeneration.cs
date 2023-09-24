using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

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


    private const float pipeOffset = 1.14f;

    void Start()
    {
        Generate(10, 0f);
    }

    public void GenerateStar(int type, Vector2 worldCoords)
    {
        Debug.Log(stars[type]);
        Instantiate(stars[type], new Vector3(worldCoords.x, worldCoords.y, -0.3f), Quaternion.identity);
    }

    public void GeneratePipes(Vector2 worldCoordinates)
    {
        Vector3 worldCoords = new Vector3(worldCoordinates.x, worldCoordinates.y + pipeOffset * 0.5f, -0.2f);

        Instantiate(pipe, worldCoords, Quaternion.identity);
        Instantiate(pipe, worldCoords + new Vector3(0, pipeOffset * 1), Quaternion.identity);
        Instantiate(pipe, worldCoords + new Vector3(0, pipeOffset * 2), Quaternion.identity);
        Instantiate(pipe, worldCoords + new Vector3(0, pipeOffset * 3), Quaternion.identity);
        Instantiate(pipe, worldCoords + new Vector3(0, pipeOffset * 4), Quaternion.identity);
        Instantiate(pipe, worldCoords + new Vector3(0, pipeOffset * 5), Quaternion.identity);
        Instantiate(pipe, worldCoords + new Vector3(0, pipeOffset * 6), Quaternion.identity);
    }

    public void GenerateBG(float yOffset)
    {
        Instantiate(background, new Vector3(0, -yOffset, 1f), Quaternion.identity);
    }

    public void Generate(int numOfRocks, float yOffset){

        ranType = Random.Range(1, 10);
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
}
