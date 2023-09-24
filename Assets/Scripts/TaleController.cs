using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TaleController : MonoBehaviour
{
    public Camera m_camera;
    public GameObject brush;

    LineRenderer currentLineRenderer;

    Vector2 lastPos;

    private bool Stopped = false;

    private void Update()
    {
        if (!Stopped)
            Drawing();  
    }


    void Drawing()
    {
        AddAPoint();
    }

    public void CreateBrush()
    {
        GameObject brushInstance = Instantiate(brush);
        currentLineRenderer = brushInstance.GetComponent<LineRenderer>();

        //because you gotta have 2 points to start a line renderer, 
        Vector2 mousePos = transform.position;

        currentLineRenderer.SetPosition(0, mousePos);
        currentLineRenderer.SetPosition(1, mousePos);

        Stopped = false;

    }

    void AddAPoint(Vector2 pointPos)
    {
        if(currentLineRenderer != null)
        {
            currentLineRenderer.positionCount++;
            int positionIndex = currentLineRenderer.positionCount - 1;
            currentLineRenderer.SetPosition(positionIndex, pointPos);
        }
    }

    private void AddAPoint()
    {
        Vector2 mousePos = transform.position;
        if (lastPos != mousePos)
        {
            AddAPoint(mousePos);
            lastPos = mousePos;
        }
    }

    public void StopTale()
    {
        currentLineRenderer = null;
        Stopped = true;
    }

}