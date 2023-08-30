using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraClamp : MonoBehaviour
{
    [SerializeField]
    private Transform targetToFollow;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(
            Mathf.Clamp(targetToFollow.position.x, 0.0f, 31.0f),
            Mathf.Clamp(targetToFollow.position.y, -0.43f, -0.43f),
            transform.position.z);

    }
}
