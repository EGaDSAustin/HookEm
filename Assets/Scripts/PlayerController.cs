using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody playerRigidbody;
    [SerializeField] private float translationSpeed;
    [SerializeField] private float maxTranslationSpeed;
    [SerializeField] private float rotationSpeed;

    void FixedUpdate ()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        MovePlayer(playerRigidbody.transform.TransformDirection(new Vector3(0, 0, vertical)));
        TurnPlayer(new Vector3(0, horizontal, 0));
    }

    private void MovePlayer (Vector3 velocity)
    {
        Vector3 newVelocity = playerRigidbody.velocity + (velocity * translationSpeed);
        playerRigidbody.velocity = Vector3.ClampMagnitude(newVelocity, maxTranslationSpeed);
    }

    private void TurnPlayer (Vector3 rotation)
    {
        playerRigidbody.rotation *= Quaternion.Euler(rotationSpeed * rotation);
    }
}
