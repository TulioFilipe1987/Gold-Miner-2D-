﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeRenderer : MonoBehaviour{

    private LineRenderer lineRenderer;

    [SerializeField]
    private Transform startPosition;   // transformé a posicao dos componetes

    private float line_Width = 0.05f;


    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();

        lineRenderer.startWidth = line_Width;

        lineRenderer.enabled = false;

    }
    
    void Start()
    {
        
    }

    public void RenderLine(Vector3 endPosition, bool enabledRenderer){

        if (enabledRenderer){

            if (!lineRenderer.enabled){ lineRenderer.enabled = true; }

            lineRenderer.positionCount = 2;

        }
        else{

            lineRenderer.positionCount = 0;

            if (lineRenderer.enabled){ lineRenderer.enabled = false; }
        
        }

        if (lineRenderer.enabled){

            // start possition
            Vector3 temp = startPosition.position;
            temp.z = -10f; // you change now to -10f 

            startPosition.position = temp;
            
            // end position
            temp = endPosition;
            temp.z = 0f;

            endPosition = temp;

            lineRenderer.SetPosition(0, startPosition.position);
            lineRenderer.SetPosition(1, endPosition);

        }
  
    
    }// draw line 
   
}