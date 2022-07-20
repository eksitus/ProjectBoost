using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    Rigidbody rigidBody;

    [SerializeField]float thrust = 1000f;
    [SerializeField] float rotationSpeed = 100f;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }



    void ProcessThrust()
    {   
        if (Input.GetKey(KeyCode.Space))
        {
            rigidBody.AddRelativeForce(Vector3.up * Time.deltaTime * thrust);
        }
        
    }



    void ProcessRotation()
    {   
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationSpeed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-1 * rotationSpeed);
        }
    }

    void ApplyRotation(float rotation)
    {
        rigidBody.freezeRotation = true;

        transform.Rotate(Vector3.forward * rotation * Time.deltaTime);

        rigidBody.freezeRotation = false;
    }





}
