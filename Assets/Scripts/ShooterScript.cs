using System; // for Math
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterScript : MonoBehaviour
{
    public CircleScript circleScript;
    public int playerNumber;
    private Rigidbody rigidbodyComponent;

    void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    //void Update()
    //{

    //}
    private float startX;
    private float startY;
    private float startTime;

    void OnMouseDown()
    {
        // Take note of position and time
        startX = Input.mousePosition.x;
        startY = Input.mousePosition.y;
        startTime = Time.time;

        circleScript.SwapTurns(playerNumber);
    }

    public float forceDampening = 1000f;

    void OnMouseUp()
    {
        // Calculate offsets
        float xOffset = Input.mousePosition.x - startX;
        float yOffset = Input.mousePosition.y - startY;
        float time = Time.time - startTime;

        // Speed = distance/time
        float force = (float) Math.Sqrt(xOffset * xOffset + yOffset * yOffset) / time;
        force = Math.Min(force, 4500); // if it's too high, the ball can go out of the table
        Vector3 forceVector = new Vector3(xOffset, 0, yOffset) * force / forceDampening; // 1k is just an arbitrary amount so the impulse is not THAT strong

        //Debug.Log($"({xOffset}, {yOffset}), time: {time}, force: {force}");
        rigidbodyComponent.AddForce(forceVector);
    }
}
