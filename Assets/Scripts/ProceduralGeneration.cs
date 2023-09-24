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

    void Start()
    {
        Generate(10, 0f);
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
