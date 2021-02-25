using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float smoothing = 1f;
    private float _speed = 1f;
    private GameObject _player;
    [SerializeField] private Animator enemyAnim;
    private GameManager gameManager;

    private void Start()
    {
        _player = GameObject.Find("Player");
        gameManager = GameObject.Find("Enemy Generator").GetComponent<GameManager>();
        StartCoroutine(FUpdate());
    }

    private IEnumerator FUpdate()
    {
        while (Vector3.Distance(transform.position,
            _player.transform.position) > 0.05f) {
            transform.position = Vector3.Lerp(transform.position,
                _player.transform.position, _speed * smoothing * Time.deltaTime);
            Vector3 relativePos = _player.transform.position - transform.position;
            transform.rotation = Quaternion.LookRotation(relativePos);
            yield return null;
        }       
    }
    private IEnumerator EnemyDestroy()
    {

        _speed = 0;
        enemyAnim.SetFloat("Speed_f", 0f);
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }



    private void OnCollisionEnter(Collision collision)
    {
        //On Collision with Player eats Players food 
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player");
            _speed = 0;
            enemyAnim.SetFloat("Speed_f", 0f);
            enemyAnim.SetBool("Eat_b", true);
            Destroy(gameObject, 6.0f);
        }
        //On Collision with an Obstacle or other EnemyPrefabs
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            StartCoroutine(EnemyDestroy());
            gameManager.ScoreUpdate(13);
        }
    }
}
