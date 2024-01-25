using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{

    [SerializeField]private Transform player;


   // public int sceneIndexToStopFollow = 4;

    private void Update()
    {

        Scene currentScene = SceneManager.GetActiveScene();


        // Check if the current scene index matches the specified scene index
       // if (currentScene.buildIndex == sceneIndexToStopFollow)
       // {
            // Camera won't follow the player in this scene
       //     return;
       // }




        transform.position =
            new Vector3(player.position.x,
            player.position.y +2f,
            transform.position.z);
    }
}
