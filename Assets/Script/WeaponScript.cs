using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponScript : MonoBehaviour {
    // Bullet Prefab
    public GameObject BulletPrefab;
    
    // Bullet Speed
    public float BulletSpeed;

    // Ammo
    // public int Ammo = 10, MaxAmmo = 10;

    public int MaxAmmo = 10;
    private int mAmmo = 10;

    public int Ammo{
        get{
            return mAmmo;
        }
        set{
            mAmmo = value;
            Ammocounter.text = Ammo + "/" + MaxAmmo;
        }
    }

    private float heat = 0.0f;
    public float heatPerRound = 0.1f;
    public float coolRate = 0.5f;
    public float iunaccuracy = 0.2f;
    public TMP_Text Ammocounter;

    // Start is called before the first frame update
    void Start() {
        mAmmo = MaxAmmo;
    }

    // Update is called once per frame
    void Update() {
        heat = Mathf.Clamp(heat - coolRate * Time.deltaTime, 0.0f, 1.0f);
    }

    public void Fire() {       
        // If Weapon is loaded
        if(Ammo > 0) {
            // Create a Bullet
            GameObject bullet = Instantiate(BulletPrefab, transform.position + transform.up * 0.08688275f + transform.forward * 0.5720212f, transform.rotation);

            Vector3 randomDirection = new Vector3(Random.Range(-heat*iunaccuracy, heat*iunaccuracy), Random.Range(-heat*iunaccuracy, heat*iunaccuracy), 0.0f);
            
            // Add a force to the bullet
            bullet.GetComponent<Rigidbody>().AddRelativeForce((Vector3.forward+randomDirection) * BulletSpeed, ForceMode.VelocityChange);

            // Decrease the Ammo
            Ammo--;

            heat = Mathf.Clamp(heat + heatPerRound, 0.0f, 1.0f);
        }
    }

    public void Reload() {
        // Reset Ammo to Max
        Ammo = MaxAmmo;
    }
}
