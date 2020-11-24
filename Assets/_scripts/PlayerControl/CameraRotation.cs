using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    private float mouseX, mouseY; //translate as right thumbstick as well
    private float rotX, rotY;
    [SerializeField] private float mouseSensitivity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        rotX += mouseX * mouseSensitivity * Time.deltaTime;
        rotY -= mouseY * mouseSensitivity * Time.deltaTime;
        rotY = Mathf.Clamp(rotY, -40f, 40f);

        transform.rotation = Quaternion.Euler(rotY, rotX, 0);
    }
}
