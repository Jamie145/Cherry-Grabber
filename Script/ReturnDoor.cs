using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ReturnDoor : MonoBehaviour
{
    private int targetSceneIndex = 0;
    private bool playerInsiddeZone = false;
    private void Update() { 
    
        if (playerInsiddeZone && Input.GetKey("w"))
        {
            Debug.Log("W or Up Arrow was pressed");

            LoadTargetScene();
        }
    }

    private void LoadTargetScene()
    {
        SceneManager.LoadScene(targetSceneIndex);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Inside zone");
            playerInsiddeZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Outside zone");
            playerInsiddeZone = false;
        }
    }

}
