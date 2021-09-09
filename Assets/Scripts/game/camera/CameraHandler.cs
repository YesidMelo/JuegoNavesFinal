using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    public GameObject MainCamera;
    public GameObject MapCamera;

    // Update is called once per frame
    void Update()
    {
        MainCamera.transform.position = new Vector3(transform.position.x, transform.position.y, MainCamera.transform.position.z);
        MainCamera.transform.rotation = Quaternion.Euler(0, 0, -transform.rotation.z);
    }
}
