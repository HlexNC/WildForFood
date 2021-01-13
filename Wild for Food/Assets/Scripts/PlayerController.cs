using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10f;
    public float turnSpeed;
    private float _rightInput;
    public bool gameOver;
    public Animator playerAnim;

    // Update is called once per frame
    private void Start()
    {
        playerAnim = GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        if (!gameOver)
        {
            _rightInput = Input.GetAxis("Horizontal");

            transform.Translate(Vector3.forward * (Time.deltaTime * speed));
            transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * _rightInput);
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over");
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
        }
    }
}
