using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineTo : MonoBehaviour
{

    /**
     * This updates a LineRenderer that is on the game object to always point between a gui element and a game object
     * This is useful for call out popups or other ui elements that need to point at something in the world space.
     *
     * Must be provided with a source gui object and a target object.
     * 
     * If the cam is not provided it will default to Camera.main
     */

    public GameObject guiObject;
    public GameObject target;

    public Camera cam;
    
    private LineRenderer lineRenderer;
    
    void Start()
    {
        // Find the line renderer
        lineRenderer = gameObject.GetComponent<LineRenderer>();
        
        // if we have not been given a camera use the main one for convenience.
        if (this.cam == null)
        {
            this.cam = Camera.main;
        }
    }

    void Update()
    {
        // Create start and end points and apply them to the lineRenderer
        Vector3[] points = 
        {
            cam.ScreenToWorldPoint(guiObject.transform.position),
            target.transform.position
        };
        lineRenderer.SetPositions(points);
    }
}
