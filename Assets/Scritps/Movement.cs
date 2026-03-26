using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Movement Properties")]
    public float forwardAcceleration = 8f;
    public float reverseAcceleration = 4f;
    public float turnSpeed = 180f;

    [Header("Wheel Properties")]
    [SerializeField] private Transform rightFrontWheel;
    [SerializeField] private Transform leftFrontWheel;
    [SerializeField] private float maxWheelTurn = 25f;

    [Header("Skid Trails Properties")]
    [SerializeField] private TrailRenderer[] skidTrails;

    private float forwardInput, turnInput;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        //gather input
        forwardInput = 0f;
        if(Input.GetAxis("Vertical") > 0)
        {
            forwardInput = Input.GetAxis("Vertical") * forwardAcceleration * 1000f;
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            forwardInput = Input.GetAxis("Vertical") * reverseAcceleration * 1000f;
        }

        turnInput = Input.GetAxis("Horizontal");
        
        //rotate wheels
        if (forwardInput < 0)
        {
            rightFrontWheel.localRotation = Quaternion.Euler(rightFrontWheel.localRotation.x, rightFrontWheel.localRotation.y, turnInput * maxWheelTurn);
            leftFrontWheel.localRotation = Quaternion.Euler(leftFrontWheel.localRotation.x, leftFrontWheel.localRotation.y, turnInput * maxWheelTurn);
        }
        else
        {
            rightFrontWheel.localRotation = Quaternion.Euler(rightFrontWheel.localRotation.x, rightFrontWheel.localRotation.y, -turnInput * maxWheelTurn);
            leftFrontWheel.localRotation = Quaternion.Euler(leftFrontWheel.localRotation.x, leftFrontWheel.localRotation.y, -turnInput * maxWheelTurn);
        }


        if(turnInput != 0 && forwardInput > 0)
        {
            for(int i = 0; i < skidTrails.Length; i++)
            {
                skidTrails[i].gameObject.GetComponent<TrailRenderer>().emitting = true;
            }
        }
        else
        {
            for (int i = 0; i < skidTrails.Length; i++)
            {
                skidTrails[i].gameObject.GetComponent<TrailRenderer>().emitting = false;
            }
        }
    }

    private void FixedUpdate()
    { 
        //add force to the car
        if (Mathf.Abs(forwardInput) > 0)
        {
            rb.AddForce(transform.up * forwardInput);
        }
        //rotate the car
        if(forwardInput != 0)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, 0f, -turnInput * turnSpeed * Time.deltaTime));
        }       
    }
}
