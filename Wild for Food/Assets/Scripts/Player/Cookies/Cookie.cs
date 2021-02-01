using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cookie : MonoBehaviour
{
    public GameObject player;
    public int speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(Vector3.up, speed * 10 * Time.deltaTime);
        transform.position = player.transform.position + new Vector3(0, 3.8f, 0);
    }
}
