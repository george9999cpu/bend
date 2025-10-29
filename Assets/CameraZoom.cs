using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{


    private Camera Cam;
public float TargetZoom = 3; 
float ScrollData; 
 float ZoomSpeed = 3; 
   
    void Start()
    {
        
Cam = GetComponent<Camera>();
TargetZoom = Cam.orthographicSize; 

    }

    // Update is called once per frame
    void Update()
    {
        
ScrollData = Input.GetAxis("Mouse Scrollwheel");
TargetZoom = TargetZoom - ScrollData;
TargetZoom = Mathf.Clamp(TargetZoom, 3, 6);
        Cam.orthographicSize = Mathf.Lerp(Cam.orthographicSize, TargetZoom, Time.deltaTime * ZoomSpeed);
    }
}
