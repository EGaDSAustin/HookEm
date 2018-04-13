using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class GrapplingHookController : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private Rigidbody endLocation;
    [SerializeField] private float sendSpeed;
    private Vector3[] linePositions;
    
    void Start ()
    {
        lineRenderer.positionCount = 2;
        linePositions = new Vector3[] { transform.position, endLocation.position };
    }

    void Update ()
    {
        if (Input.GetButton("Grappling Hook"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                SendGrapplingHook(hit.point, sendSpeed);
            }
            else
            {
                Debug.LogError("GrapplingHookController.Update: Grappling hook raycast didn't hit any colliders");
            }
        }

        UpdateLineRenderer();
    }

    private void SendGrapplingHook (Vector3 newPosition, float speed)
    {
        //Vector3 originalPosition = );
        //for (float t = 0; t < 1; t += speed)
        //{
        endLocation.MovePosition(newPosition);//Vector3.Lerp());
        //    yield return null;
        //}
    }

    private void UpdateLineRenderer ()
    {
        linePositions[0] = transform.position;
        linePositions[1] = endLocation.position;
        lineRenderer.SetPositions(linePositions);
    }
}
