using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BirdScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public float upwardForce;
    private GameManager gameManager;
    public int score = 0;
    private bool _isGameOver = false;
    [SerializeField] private AudioSource jumpSoundEffect;
    [SerializeField] private AudioSource deathSoundEffect;
 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        _isGameOver = false;
    }

    private void FixedUpdate() {
        if(transform.position.y < -6 || transform.position.y > 6) {
            gameManager.GameOver();
        }
    }

    public void Jump(InputAction.CallbackContext context) {
        if(_isGameOver == false && context.performed) {
            rb.velocity = Vector2.up * upwardForce;
            jumpSoundEffect.Play();
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "MiddlePillar") {
            score++;
            gameManager.UpdateScore(score);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(_isGameOver == false) {
            gameManager.GameOver();
            deathSoundEffect.Play();
            _isGameOver = true;
        }
        
    }
}
