using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using Random = System.Random;


public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    public Rigidbody body;
    private bool moveForward;
    private bool moveBack;
    private GameObject o;
    public float RunSpeed = 5f;

    public Collider CoPlayer;
    public Collider CoSphere;
    private bool ground;

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

    private void OnCollisionEnter(Collision collision)
    {
        ground = true;
    }

    private void OnCollisionExit(Collision other)
    {
        ground = false;
    }

    private void FixedUpdate()
    {
        Vector3 angel = transform.position - o.transform.position;
        // transform.Rotate(Quaternion.FromToRotation(transform.up, angel).eulerAngles);
        transform.rotation = Quaternion.FromToRotation(transform.up, angel) * transform.rotation;

        // RaycastHit hit = new RaycastHit();
        // CoPlayer.Raycast(new Ray(transform.position, transform.up * -1), out var hit, 10);
        // Debug.DrawRay(transform.position,transform.up*-1,Color.magenta);
        // Debug.DrawRay(hit.point,hit.normal,Color.cyan);
        // Debug.Log("normal= " + hit.normal + "  down=" + transform.up * -1);

        //gravity
        if (!ground)
        {
            body.AddForce(transform.up.normalized * -9.8f, ForceMode.Acceleration);
            Debug.Log(body.velocity.magnitude);
            return;
        }

        if (moveForward)
        {
            body.velocity = transform.forward * RunSpeed / Time.timeScale;
            Debug.Log(transform.forward.magnitude);
        }
        else
        {
            body.velocity = Vector3.zero;
        }
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