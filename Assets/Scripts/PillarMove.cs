using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarMove : MonoBehaviour
{
    public float speed = 5f;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = transform.position + Vector3.left * speed * Time.deltaTime;
        if(transform.position.x < -22.0f)
            Destroy(this.gameObject);
    }
}
