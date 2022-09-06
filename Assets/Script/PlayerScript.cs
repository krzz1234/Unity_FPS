using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
    // Character Controller
    private CharacterController mController;
    
    // Player Speed
    public float Speed = 5.0f, JumpSpeed = 5.0f;

    // Gravity
    private float mGravity = -9.81f;

    // Velocity
    private Vector3 mVelocity;

    // Look Angle
    private float mThetaX, mThetaY;

    // Torso
    public Transform Torso;

    // Weapon
    public WeaponScript Weapon;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        mController = GetComponent<CharacterController>();
        mVelocity = Vector3.zero;
    }

    // Update is called once per frame
    void Update() {
        // Input from Keyboard
        mThetaX = Mathf.Clamp(mThetaX-Input.GetAxis("Mouse Y"), -65, 65);
        mThetaY +=  Input.GetAxis("Mouse X");

        // Rotate the Player and Camera
        transform.rotation = Quaternion.AngleAxis(mThetaY, Vector3.up);
        Torso.localRotation = Quaternion.AngleAxis(mThetaX, Vector3.right);

        // If Controller is Grounded 
        if(mController.isGrounded) {
            // Player - Walk
            Vector3 forward = transform.forward * Input.GetAxis("Vertical") * Speed;
            Vector3 right = transform.right * Input.GetAxis("Horizontal") * Speed;

            // Horizontal movement based on input
            mVelocity.x = mVelocity.z = 0;
            mVelocity += forward + right;

            // Player - Jump
            if(Input.GetKeyDown("space")) {
                mVelocity.y = JumpSpeed;
            }
        }

        // Apply Gravity
        mVelocity.y += mGravity * Time.deltaTime;

        // Move Controller
        mController.Move((mVelocity) * Time.deltaTime);

        // User Pressed Left Mouse Button
        if(Input.GetMouseButtonDown(0)) {
            // Fire Weapon
            Weapon.Fire();
        }

        // User Pressed 'R' Key
        if(Input.GetKeyDown(KeyCode.R)) {
            // Reload Weapon
            Weapon.Reload();
        }
    }
}
