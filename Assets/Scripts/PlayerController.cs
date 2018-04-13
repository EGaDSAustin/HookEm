using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody playerRigidbody;
    [SerializeField] private Camera camera;
    [SerializeField] private float translationSpeed;
    [SerializeField] private float maxTranslationSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float jumpForce;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void FixedUpdate ()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        MovePlayer(playerRigidbody.transform.TransformDirection(new Vector3(horizontal, 0,vertical)));

        //jump
        jump(new Vector3(0, Input.GetAxis("Jump"),0));

        //camera rotation
        TurnPlayer(new Vector3(0, Input.GetAxis("Mouse X"), 0));
        TurnCamera(new Vector3(-1 * Input.GetAxis("Mouse Y"),0, 0));

        
    }
    
    private void MovePlayer (Vector3 velocity)
    {
        Vector3 newVelocity = playerRigidbody.velocity + (velocity * translationSpeed);
        playerRigidbody.velocity = Vector3.ClampMagnitude(newVelocity, maxTranslationSpeed);
    }

    private void jump(Vector3 jump)
    {
        Vector3 newVelocity = playerRigidbody.velocity + (jump * jumpForce);
        playerRigidbody.velocity = Vector3.ClampMagnitude(newVelocity, maxTranslationSpeed);
    }

    private void TurnPlayer (Vector3 rotation)
    {
        playerRigidbody.rotation *= Quaternion.Euler(rotationSpeed * rotation);
    }

    private void TurnCamera(Vector3 rotation)
    {
        camera.transform.rotation *= Quaternion.Euler(rotation * rotationSpeed);
    }
}
