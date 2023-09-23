using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProceduralGeneration : MonoBehaviour
{

    [SerializeField] int height;
    float width;
    [SerializeField] GameObject rock1, rock2, rock3, rock4, oil;
    [SerializeField] Camera cam;
    int ranType, curType;

    void Start()
    {
        Generate();
    }

    void Generate(){

        ranType = Random.Range(1, 10);
        for (int i=0;i<height;i++){
            width = cam.ViewportToWorldPoint(new Vector3(Random.Range(0.1f, 0.9f), 0, 0)).x;
            do {
                curType = Random.Range(1, 10);
            } while (curType == ranType);
            spawnObject(curType, i);

            ranType = curType;
        }
    }

    void spawnObject(int type, int i)
    {
        if (type == 7)
        {
            Instantiate(rock4, new Vector2(width, -i * 5), Quaternion.identity);
        }
        else if (type%4 == 1)
        {
            Instantiate(rock1, new Vector2(width, -i * 5), Quaternion.identity);
        }
        else if(type%4==2)
        {
            Instantiate(rock2, new Vector2(width, -i * 5), Quaternion.identity);
        } else if(type%4==3)
        {
            Instantiate(rock3, new Vector2(width, -i * 5), Quaternion.identity);
        }
        else
        {
            Instantiate(rock4, new Vector2(width, -i * 5), Quaternion.identity);
        }

    }
}
