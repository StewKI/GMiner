using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float drillSpeed = 1f;
    public float laziness = 0.1f;

    private bool started = false;
    private float actualSpeed = 0f;

    // Start is called before the first frame update
    void Start()
    {

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

        transform.position = new Vector3(transform.position.x, transform.position.y - (actualSpeed * Time.deltaTime), transform.position.z);
    }
}
