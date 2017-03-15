﻿using UnityEngine;
using System.Collections;

public class CameraFolow : MonoBehaviour
{

    public float xMargin = 1f;      // Distance in the x axis the player can move before the camera follows.
    public float yMargin = 1f;      // Distance in the y axis the player can move before the camera follows.
    public float xSmooth = 3f;      // How smoothly the camera catches up with it's target movement in the x axis.
    public float ySmooth = 3f;      // How smoothly the camera catches up with it's target movement in the y axis.
    public Vector2 maxXAndY;        // The maximum x and y coordinates the camera can have.
    public Vector2 minXAndY;        // The minimum x and y coordinates the camera can have.

    public float smoothTimeX;
    public float smoothTimeY;

    private Vector2 velocity;
    private Rigidbody2D rb;
    public Transform target;

    bool CheckXMargin()
    {
        // Returns true if the distance between the camera and the player in the x axis is greater than the x margin.
        return Mathf.Abs(transform.position.x - target.position.x) > xMargin;
    }


    bool CheckYMargin()
    {
        // Returns true if the distance between the camera and the player in the y axis is greater than the y margin.
        return Mathf.Abs(transform.position.y - target.position.y) > yMargin;
    }


    void FixedUpdate()
    {
        // By default the target x and y coordinates of the camera are it's current x and y coordinates.
        float targetX = transform.position.x;
        float targetY = transform.position.y;
        // If the player has moved beyond the x margin...
        if (CheckXMargin())
            // ... the target x coordinate should be a Lerp between the camera's current x position and the player's current x position.
            targetX = Mathf.Lerp(transform.position.x, target.position.x, xSmooth * Time.deltaTime);
        Debug.Log(targetX);
        // If the player has moved beyond the y margin...
        //if (CheckYMargin())
        //    // ... the target y coordinate should be a Lerp between the camera's current y position and the player's current y position.
        //    targetY = Mathf.Lerp(transform.position.y, target.position.y, ySmooth * Time.deltaTime);
        // Set the camera's position to the target position with the same z component.
        transform.position = new Vector3((float) targetX, transform.position.y, transform.position.z);
    }
}
