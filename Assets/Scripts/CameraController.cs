using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float zoomSensitvity;
    Vector3 mouseOriginPoint;
    Vector3 offset;
    bool dragging;
    private void LateUpdate()
    {// values between
       Camera.main.orthographicSize= Mathf.Clamp( 
            (Camera.main.orthographicSize -= Input.GetAxis("Mouse ScrollWheel")* (zoomSensitvity*Camera.main.orthographicSize*.1f))
            ,2.5f
            ,50f);
        if (Input.GetMouseButton(0))
        {
            //substract from mouse pos cam pos
            offset = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
            if (!dragging)
            {
                dragging = true;
                //get mouse pos
                mouseOriginPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }
        else
            dragging = false;
        if(dragging)
        {
            // move camera in opposite size to mouse cursor
            transform.position = mouseOriginPoint- offset;
        }
    }
}
