using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject thingToFollow;
    // Camera position should match cars position
    void LateUpdate()
    {
        transform.position = thingToFollow.transform.position + new Vector3(0, 0, -10);
        // transform.rotation = thingToFollow.transform.rotation;
    }
}
