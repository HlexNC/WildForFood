using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float smoothing = 1f;
    private float _speed = 1f;
    private GameObject _player;
    public Animator enemyAnim;
    private Rigidbody enemyRb;
    private bool _returnBack;
    private Vector3 _startPos;

    private void Start()
    {
        _player = GameObject.Find("Player");
        enemyAnim = GetComponent<Animator>();
        enemyRb = gameObject.GetComponent<Rigidbody>();
        _startPos = transform.position;
    }

    private void FixedUpdate()
    {
            transform.position = Vector3.Lerp(transform.position, _player.transform.position, _speed * smoothing * Time.deltaTime);
    }
    private IEnumerator EnemyDestroy1()
    {

        _speed = 0;
        enemyAnim.SetFloat("Speed_f", 0);
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
    private IEnumerator EnemyDestroy2()
    {
        _speed = 0;
        enemyAnim.SetFloat("Speed_f", 0.5f);
        while (Vector3.Distance(transform.position, _startPos) > 0.05f)
        {
            transform.position = Vector3.Lerp(transform.position, _startPos, 0.5f * smoothing * Time.deltaTime);

            yield return null;
        }
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }



    private void OnCollisionEnter(Collision collision)
    {
        //On Collision with Player eats Players food (doesn't work: gets destroyed straight away)
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player");
            _speed = 0;
            enemyAnim.SetBool("Eat_b", true);
            Destroy(gameObject, 5.0f);
        }
        //On Collision with an Obstacle or other EnemyPrefabs
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            //generates a number between 0 and 1 to chose an action
            int randomAction = Random.Range(0, 2);
            if (randomAction == 0)
            {
                EnemyDestroy1();
            }
            if (randomAction == 1)
            {
                StartCoroutine(EnemyDestroy2());
            }
            Debug.Log("Obstacle " + randomAction);
        }
    }
}
