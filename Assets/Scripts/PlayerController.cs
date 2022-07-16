using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    public Rigidbody body;
    private bool moveForward;
    private bool moveBack;
    private GameObject o;
    public float RunSpeed = 5f;
    void Start()
    {
         o = GameObject.Find("Sphere");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            moveForward = true;
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            moveForward = false;
        }
        // if (Input.GetKey(KeyCode.S))
        // {
        //     body.velocity = new Vector3(0, 0, -5);
        // }
        //
        // if (Input.GetKeyUp(KeyCode.S))
        // {
        //     body.velocity = new Vector3(0, 0, 0);
        // }
    }

    private void FixedUpdate()
    {
        if (moveForward)
        {
            body.velocity = transform.forward * RunSpeed;
        }
        else
        {
            body.velocity = Vector3.zero;
        }
        
        Vector3 angel = transform.position - o.transform.position;
        // transform.Rotate(Quaternion.FromToRotation(transform.up, angel).eulerAngles);
        transform.rotation = Quaternion.FromToRotation(transform.up, angel) * transform.rotation;
        Debug.Log(Quaternion.FromToRotation(transform.up,angel).eulerAngles.magnitude);
        body.AddForce(angel * -9.8f);
    }

    [Button]
    void Change()
    {
        GameObject o = GameObject.Find("Sphere");
        Vector3 angel = transform.position - o.transform.position;
        Vector3 a2 = transform.position + angel;

        Debug.DrawLine(transform.position, a2, Color.blue, 10);
        Debug.DrawLine(o.transform.position, transform.position, Color.magenta, 10);
        transform.Rotate(Quaternion.FromToRotation(transform.up, angel.normalized).eulerAngles);
    }
}