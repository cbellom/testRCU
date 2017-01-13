using UnityEngine;
using System.Collections;

public class MoveController : MonoBehaviour
{
    [SerializeField]
    private float jumpForce = 10f;
    [SerializeField]
    private Quaternion rotation;
    [SerializeField]
    private Vector3 radius = new Vector3(5, 0, 0);

    private float currentRotation = 0.0f;
    private Rigidbody playerRigidbody;

    void Awake() {
        playerRigidbody = GetComponent<Rigidbody>();
        UpdateRadiusToAxisYPosition();
    }

    void Update() {
        UpdateRadiusToAxisYPosition();
        GetInputToMove();
    }

    private void UpdateRadiusToAxisYPosition() {
        radius.y = transform.position.y;
    }

    private void GetInputToMove() {
        currentRotation += Input.GetAxis("Horizontal") * Time.deltaTime * 100;
        rotation.eulerAngles = new Vector3(0, currentRotation, 0);
        transform.position = rotation * radius;

        transform.rotation = rotation;
    }

    private void getInputToJump() {
        if (Input.GetAxis("Vertical") > 0)
            playerRigidbody.AddForce(0, jumpForce, 0); ;
    }
}
