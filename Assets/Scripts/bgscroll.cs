using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgscroll : MonoBehaviour
{
    public float length;
    public float speed = 4f;
    private Vector3 startPos;
    private void Start() {
        startPos = transform.position;
        length = GetComponent<Renderer>().bounds.size.x;
    }

    private void FixedUpdate() {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        if(transform.position.x < startPos.x - length) {
            transform.position = startPos;
        }
    }
}
