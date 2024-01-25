using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Finish : MonoBehaviour
{

    private AudioSource finishSound;

    private bool levelCompleted = false;



    // Start is called before the first frame update
   private void Start()
    {
        finishSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !levelCompleted)
        {
            finishSound.Play();

            // Access the Timer script on the Timer game object
            Timer timer = GameObject.FindObjectOfType<Timer>();

            if (timer != null)
            {
                // Call the GameCompleted method to stop the timer
                timer.GameCompleted();
            }


            Invoke("CompleteLevel", 1.5f);
            levelCompleted = true;
            Debug.Log("Collision Happenend");
        }
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

}
