using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject generator;
    private ProceduralGeneration pGen;

    public float drillSpeed = 1f;
    public float laziness = 0.1f;

    private bool started = false;
    private float actualSpeed = 0f;

    private const float HeightBG = 13.96f;
    private float dokleDoso = -HeightBG / 2; //TODO : rename
    private int numOfSpawnedBGs = 0;

    // Start is called before the first frame update
    void Start()
    {
        pGen = generator.GetComponent<ProceduralGeneration>();
        //pGen.Generate()
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (actualSpeed < drillSpeed)
                actualSpeed += laziness;
        }
        else
        {
            if (actualSpeed > 0f)
                actualSpeed -= laziness;
        }
        actualSpeed = drillSpeed; //TEMP TESTING

        transform.position = new Vector3(transform.position.x, transform.position.y - (actualSpeed * Time.deltaTime), transform.position.z);

        if(transform.position.y < dokleDoso)
        {
            dokleDoso -= HeightBG;
            numOfSpawnedBGs++;
            pGen.GenerateBG(HeightBG * (numOfSpawnedBGs + 0.5f));
            if(numOfSpawnedBGs %2 == 0)
            {
                pGen.Generate(10, - numOfSpawnedBGs * HeightBG);
            }
            Debug.Log("uradio");
        }
    }
}
