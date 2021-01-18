using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public int spawnRange;
    private GameObject cube;
    private int enemyIndex;
    // Start is called before the first frame update
    void Start()
    {
        cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        StartCoroutine(GenerateEnemy());
    }
    private IEnumerator GenerateEnemy()
    {
        enemyIndex = Random.Range(0, enemyPrefabs.Length);
        Instantiate(
            enemyPrefabs[enemyIndex],
            //cube,
            transform.position + new Vector3(Random.Range(-spawnRange, spawnRange), 0, Random.Range(-spawnRange, spawnRange)),
            enemyPrefabs[enemyIndex].transform.rotation);
        yield return new WaitForSeconds(1);
        StartCoroutine(GenerateEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
