using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    Rigidbody rigidBody;
    AudioSource audioSource;
    [SerializeField]float thrust = 1000f;
    [SerializeField] float rotationSpeed = 100f;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        
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
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
            
            //audioSource.loop = true;

        }
        else
        {
            audioSource.Stop();
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
