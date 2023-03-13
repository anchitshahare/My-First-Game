using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipe;
    public float spawnRate = 2f;
    private float timer = 0f;
    public float offset = 10f;
    // Start is called before the first frame update
    void Start()
    {
        SpawnPillar();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(timer < spawnRate) {
            timer += Time.deltaTime;
        } else {
            SpawnPillar();
            timer = 0;
        }
    }

    void SpawnPillar() {
        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(transform.position.y - offset, transform.position.y + offset)), Quaternion.identity);
    }
}
