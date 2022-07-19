using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    Rigidbody rigidBody;

    [SerializeField]float thrust = 1000f;

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
            rigidBody.AddRelativeForce(0,thrust*Time.deltaTime,0);
        }
        
    }



    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-0.01f, 0, 0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(0.01f, 0, 0);
        }
    }
}
