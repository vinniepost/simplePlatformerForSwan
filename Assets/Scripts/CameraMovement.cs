using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Transform cameraTransform;

    [SerializeField]
    private Transform target;

    [SerializeField]
    private Vector3 offset;

    // Start is called before the first frame update
    private void Start()
    {
        cameraTransform = Camera.main.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = target.position;
        cameraTransform.position = target.position + offset;
    }
}