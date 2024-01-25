using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    private Animator anim;
    [SerializeField]private int upForce = 20;
    [SerializeField] private AudioSource springSound;


    private void Start()
    {
        anim = GetComponent<Animator>();


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player" )
        {
            anim.SetBool("spring", true);
            Rigidbody2D playerRB = collision.gameObject.GetComponent<Rigidbody2D>();

            // Make sure the player doesn't maintain their current velocity
            playerRB.velocity = new Vector2(playerRB.velocity.x, 0);

            // Apply an upward force
            playerRB.AddForce(new Vector2(0, upForce), ForceMode2D.Impulse);

            springSound.Play();
        }
       
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            anim.SetBool("spring", false);
        }
    }


}
