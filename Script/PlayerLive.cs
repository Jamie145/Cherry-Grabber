using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLive : MonoBehaviour
{
    [SerializeField] private AudioSource deathSound;
    private Animator anim;
    private Rigidbody2D _rb;
    private SpriteRenderer sprite;

    [SerializeField] private Transform respawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();

        if (sprite == null)
        {
            Debug.LogError("SpriteRenderer component not found!");
        }

        //DontDestroyOnLoad(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Traps"))
        {
            Die();
            
        }

    }



    private void Die()
    {
        anim.SetTrigger("death");
        deathSound.Play();
        Invoke("FreezePlayer", 0.05f);
        
        
    }

    private void FreezePlayer()
    {
        _rb.bodyType = RigidbodyType2D.Static;

        Invoke("Respawn", 0.5f);
    }

    private void Respawn()
    {
        Debug.Log("Respawning player");
        transform.position = respawnPoint.position;
      

        _rb.bodyType = RigidbodyType2D.Dynamic;


        sprite.enabled = true;
        Debug.Log("Player respawned");
    }



    private void RestartLevel()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
