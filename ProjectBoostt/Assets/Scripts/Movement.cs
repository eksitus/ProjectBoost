using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    
    [SerializeField]float thrust = 1000f;
    [SerializeField] float rotationSpeed = 100f;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] ParticleSystem leftParticle;
    [SerializeField] ParticleSystem rightParticle;
    [SerializeField] ParticleSystem boosterParticle;

    Rigidbody rigidBody;
    AudioSource audioSource;


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


    // Thrust
    void ProcessThrust()
    {   
        if (Input.GetKey(KeyCode.Space))
        {
            StartThrust();
        }
        else
        {
            StopThrust();

        }

    }
    private void StartThrust()
    {
        rigidBody.AddRelativeForce(Vector3.up * Time.deltaTime * thrust);

        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngine);
        }
        if (!boosterParticle.isPlaying)
        {
            boosterParticle.Play();

        }
    }
    private void StopThrust()
    {
        audioSource.Stop();
        boosterParticle.Stop();
    }

    

    //Rotation

    void ProcessRotation()
    {   
        if (Input.GetKey(KeyCode.A))
        {
            RotateLeft();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            RotateRight();
        }
        else
        {
            StopRotation();
        }
        
        
    }

    void ApplyRotation(float rotation)
    {
        rigidBody.freezeRotation = true;

        transform.Rotate(Vector3.forward * rotation * Time.deltaTime);

        rigidBody.freezeRotation = false;
    }

    private void RotateLeft()
    {
        ApplyRotation(rotationSpeed);

        if (!rightParticle.isPlaying)
        {

            rightParticle.Play();
        }
    }
    private void RotateRight()
    {
        ApplyRotation(-1 * rotationSpeed);
        if (!leftParticle.isPlaying)
        {

            leftParticle.Play();
        }
    }

    

    private void StopRotation()
    {
        rightParticle.Stop();
        leftParticle.Stop();
    }

    





}
