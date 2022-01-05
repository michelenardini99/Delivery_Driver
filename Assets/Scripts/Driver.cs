using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{

    [SerializeField] float steerSpeed = 300f;
    [SerializeField] float moveSpeed = 20f;
    [SerializeField] float slowSpeed = 15f;
    [SerializeField] float boostSpeed = 30f;


    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * this.steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * this.moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        this.moveSpeed = this.slowSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Speed Boost"){
            this.moveSpeed = this.boostSpeed;
        }
    }
}
