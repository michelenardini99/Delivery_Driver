using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{

    [SerializeField] Color32 hasPackageColor = new Color32(1, 1, 1, 1); 
    [SerializeField] Color32 hasNotPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] float destroyDelay = 0.5f;
    bool hasPackage;

    SpriteRenderer spriteRenderer;

    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log(other);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Package" && !this.hasPackage){
            Debug.Log("Package picked up");
            Destroy(other.gameObject, this.destroyDelay);
            this.hasPackage=true;
            this.spriteRenderer.color = this.hasPackageColor;
        }else if(other.tag == "Delivery Location" && this.hasPackage){
            Debug.Log("Package delivered");
            this.hasPackage = false;
            this.spriteRenderer.color = this.hasNotPackageColor;
        }
    }
}
