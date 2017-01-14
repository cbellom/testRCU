using UnityEngine;
using System.Collections;

public class MoveController : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10f;
    [SerializeField]
    private float jumpForce = 10f;
    [SerializeField]
    private Vector3 radius = new Vector3(5, 0, 0);
    
    private bool isJumping = false;
    private float currentRotation = 0.0f;
	private Quaternion rotation;
    private Rigidbody playerRigidbody;
    private Animator playerAnimator;

    void Awake() {
        playerRigidbody = GetComponent<Rigidbody>();
        UpdateRadiusToAxisYPosition();
    }

    void Update() {
        GetInputToMove();
    }
    
    private void UpdateRadiusToAxisYPosition() {
        radius.y = transform.position.y;
    }

    private void GetInputToMove() {

        if (Input.GetAxis("Vertical") > 0)
            transform.position += transform.up * jumpForce * Time.deltaTime;

        currentRotation += Input.GetAxis("Horizontal") * Time.deltaTime * moveForce;
        rotation.eulerAngles = new Vector3(0, -currentRotation, 0);
        
        transform.position = rotation * radius;
        
        transform.position = rotation * radius;
        transform.rotation = rotation;
    }

    private void PlayRunAnimation(float moveSpeed) {
        if(Input.GetKeyDown("a") || Input.GetKeyDown("d")) {
            playerAnimator.SetFloat("moveSpeed", moveSpeed);
        }
    }
    
}
