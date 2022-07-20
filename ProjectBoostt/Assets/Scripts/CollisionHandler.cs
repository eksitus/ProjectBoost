using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CollisionHandler : MonoBehaviour
{

    [SerializeField] float delayTime = 1f;
    
    private void OnCollisionEnter(Collision collision)
    {
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

            default:
                break;
        }
    }

    void StartCrashSequence()
    {
        gameObject.GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel",delayTime);
    }

    void SuccessSequence()
    {
        gameObject.GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", delayTime);
    }



    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
    void LoadNextLevel()
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
