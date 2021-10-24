using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMove : MonoBehaviour
{
    public float smoothing = 5;
    Vector3 offset;
    public Transform target;
    float lowY;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.position;
        lowY = transform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 targetCam = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetCam, smoothing * Time.deltaTime);
    }
}
