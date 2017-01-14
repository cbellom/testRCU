using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float speed = 6.0F;
    [SerializeField]
    private float jumpSpeed = 8.0F;
    [SerializeField]
    private float gravity = 20.0F;
    [SerializeField]
    private Vector3 radius = new Vector3(5, 0, 0);

    private float currentRotation = 0.0f;
    private Vector3 moveDirection = Vector3.zero;
    private Quaternion rotation;
    private CharacterController controller;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (controller.isGrounded)
        {
            currentRotation += Input.GetAxis("Vertical") * Time.deltaTime * speed;
            rotation.eulerAngles = new Vector3(0, -currentRotation, 0);
            transform.rotation = rotation;


            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;

        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
}
