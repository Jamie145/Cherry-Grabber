using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{

    private int cherries = 0;

    [SerializeField] private AudioSource collectionSound;

    [SerializeField] private Text cherriesText;

    private const string cherryCountKey = "CherryCount";

    private PlayerMovement playerMovement;

    private void Start()
    {
        cherries = PlayerPrefs.GetInt(cherryCountKey, 0);
        UpdateCherryText();

        //DontDestroyOnLoad(gameObject);

        playerMovement = GetComponent<PlayerMovement>();

    }



    private void UpdateCherryText()
    {
        cherriesText.text = "x " + cherries;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject.CompareTag("Cherry")) 
        {
            Destroy(collision.gameObject);
            cherries++;
            cherriesText.text = "x " + cherries;

            playerMovement.IncreaseMovementSpeed();

            collectionSound.Play();
        } 
    }
}
