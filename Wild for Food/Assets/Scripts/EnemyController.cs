using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float smoothing = 1f;
    private float speed = 1f;
    private GameObject _player;


    void Start()
    {
        _player = GameObject.Find("Player");
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, _player.transform.position, speed * smoothing * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player");
            speed = 0;
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Obstacle");
            Destroy(gameObject);
        }
    }
}
