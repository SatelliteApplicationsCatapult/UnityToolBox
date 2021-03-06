using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    /**
     * This script will cause the gui object that it is on to always float a given offset from the target game object.
     *
     * Requires a target game object to move the gui element over.
     * The offset controls where to move the text so it does not overlap the target.
     *
     * If no cam is provided it will default to Camera.main
     */
    
    public GameObject target;
    public Vector3 offset;
    public int roundDecimalPlaces = 2;
    
    public Camera cam;

    private float roundValue;
    void Start()
    {
        // if we have not been given a camera use the main one for convenience.
        if (this.cam == null)
        {
            this.cam = Camera.main;
        }

        roundValue = Mathf.Pow(10, roundDecimalPlaces);
    }


    void Update()
    {
        // work out where the object is on screen
        Vector3 pos = this.cam.WorldToScreenPoint(target.transform.position) + this.offset;
        pos = new Vector3(
            x: Mathf.Round(pos.x * roundValue) / roundValue,
            y: Mathf.Round(pos.y * roundValue) / roundValue,
            z: Mathf.Round(pos.z * roundValue) / roundValue
        );

            // set the transform of this to that plus the offset.
        // TODO: what happens if the object goes off screen?
        this.transform.position = pos;
    }
}
