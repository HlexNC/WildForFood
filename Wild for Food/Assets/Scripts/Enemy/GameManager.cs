using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public int spawnRange;
    private int enemyIndex;
    public TextMeshProUGUI scoreText;
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GenerateEnemy());
        score = 0;
        
    }
    private IEnumerator GenerateEnemy()
    {
        enemyIndex = Random.Range(0, enemyPrefabs.Length);
        Instantiate(
            enemyPrefabs[enemyIndex],
            transform.position + new Vector3(Random.Range(-spawnRange, spawnRange), 0, Random.Range(-spawnRange, spawnRange)),
            enemyPrefabs[enemyIndex].transform.rotation);
        yield return new WaitForSeconds(1);
        StartCoroutine(GenerateEnemy());
    }
    public void ScoreUpdate(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }
    // Update is called once per frame
}
