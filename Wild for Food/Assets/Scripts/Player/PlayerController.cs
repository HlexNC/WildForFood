using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10f;
    public float turnSpeed;
    private float _rightInput;
    public bool gameOver;
    public Animator playerAnim;
    public GameObject enemyGenerator;
    public ParticleSystem cookieParticle;
    public ParticleSystem dirtParticle;
    public GameObject cookie;
    public GameObject GameOver;

    // Update is called once per frame
    private void Start()
    {
        playerAnim = GetComponent<Animator>();
        dirtParticle.Play();
    }
    void FixedUpdate()
    {
        if (!gameOver)
        {
            _rightInput = Input.GetAxis("Horizontal");

            transform.Translate(Vector3.forward * (Time.deltaTime * speed));
            transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * _rightInput);
        }
        if (transform.position.y < -10)
        {
            SceneManager.LoadScene("StartScene");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over");
            gameOver = true;
            cookieParticle.Play();
            dirtParticle.Stop();
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            enemyGenerator.SetActive(false);
            cookieParticle.Play();
            cookie.SetActive(false);
            GameOver.SetActive(true);
        }
    }
}
