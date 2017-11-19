using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float moveSpeed;
    private Rigidbody myRigidBody;

    // Created this for player movement.
    private Vector3 moveInput;
    private Vector3 moveVelocity;

    // Created this so player follows mouse.
    private Camera mainCamera;

    // Created this for gun and bullets.
    public GunController theGun;

	// Use this for initialization
	void Start () {
        myRigidBody = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();
	}
	
	// Remember that update is called once per frame
	void Update () {
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput * moveSpeed;

        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundplane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if(groundplane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointTooLook = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, pointTooLook, Color.blue);

            transform.LookAt(new Vector3(pointTooLook.x, transform.position.y, pointTooLook.z));
        }
        if (Input.GetMouseButton(0))
            theGun.isFiring = true;

        if (Input.GetMouseButtonUp(0))
            theGun.isFiring = false;
	}

    void FixedUpdate(){
        myRigidBody.velocity = moveVelocity;
    }
}
