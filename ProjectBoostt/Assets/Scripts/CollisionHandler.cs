using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CollisionHandler : MonoBehaviour
{

    [SerializeField] float delayTime = 1f;
    [SerializeField] AudioClip successClip;
    [SerializeField] AudioClip crashClip;
    [SerializeField] ParticleSystem successParticle;
    [SerializeField] ParticleSystem crashParticle;


    AudioSource audioSource;
    BoxCollider boxCollider;
    

    bool isTransitioning = false;
    bool collisionDisable = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        boxCollider = GetComponent<BoxCollider>();

    }

    void Update()
    {
        RespondToDebugKeys();
    }

    private void RespondToDebugKeys()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadNextLevel();
        }

        else if (Input.GetKeyDown(KeyCode.C))
        {

            collisionDisable = !collisionDisable;
           
            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isTransitioning || collisionDisable)
        {
            return;
        }

        switch (collision.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Friendly");
                break;
            case "Finish":
                SuccessSequence();
                break;
            case "Fuel":
                Debug.Log("Fuel");
                break;
            case "Obstacle":
                StartCrashSequence();
                break;
            case "Portal Enter":
                Portal();
                break;
            default:
                break;
        }
    }

    void Portal()
    {
        GetComponent<Transform>().position = GameObject.FindWithTag("Portal Exit").GetComponent<Transform>().position + Vector3.down;
       
    }

        
    

    void StartCrashSequence()
    {
        isTransitioning = true;
        audioSource.Stop(); //stop all other sounds before crash clip
        audioSource.PlayOneShot(crashClip);
        crashParticle.Play();
        gameObject.GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel",delayTime);
        
    }

    void SuccessSequence()
    {
        isTransitioning = true;
        audioSource.Stop(); //stop all other sounds before success clip
        audioSource.PlayOneShot(successClip);
        successParticle.Play();
        gameObject.GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", delayTime);
        
    }



    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
    public void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if(nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }

    
}
