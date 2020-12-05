using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_ItemName : MonoBehaviour
{

    private Camera cam;
    void Start()
    {
        cam = Camera.main;    
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = cam.transform.rotation;
    }
}
