using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void OnCollisionEnter(Collision collision) {
        // If the bullet collided with a target
        if(collision.gameObject.tag == "Target") {
            // Destroy the Target
            Destroy(collision.gameObject);
        }

        // Destroy the Bullet
        Destroy(gameObject);
    }
}
