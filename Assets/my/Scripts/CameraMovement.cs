using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    //private bool mode3d = false;
    public Transform Player3D;
    public Transform Cam2DPos;
    public float smoothness = 0.1f;
    public float rotSmoothness = 0.1f;
    public float zoomSpeed = 0.3f;
    public float zoomSmoothness = 0.1f;
    public float minOffset;
    public float maxOffset;
    //private Rigidbody rb;
    private Vector3 cameraOffset;
    private Vector3 cameraOffsetRaw;
    private Quaternion defaultRot;
    private void Start()
    {
        Mode.mode = "2D";
        cameraOffset = transform.position - Player3D.position;
        cameraOffsetRaw = cameraOffset;
        defaultRot = transform.rotation;
    }

    void Update()
    {
        Vector3 targetPos;
        Quaternion targetRot;
        if (Input.GetKeyDown(KeyCode.C))
        {
            if(Mode.mode == "2D")
            {
                Mode.mode = "3D";
            }
            else
            if (Mode.mode == "3D")
            {
                Mode.mode = "2D";
            }


        }

        if (cameraOffsetRaw.magnitude > minOffset && cameraOffsetRaw.magnitude < maxOffset)
        {
            cameraOffsetRaw = cameraOffsetRaw + cameraOffsetRaw.normalized * Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
            cameraOffset = Vector3.Lerp(cameraOffset, cameraOffsetRaw, zoomSmoothness);
        }
        else
        {
            if (cameraOffsetRaw.magnitude >= maxOffset) 
            { 
                cameraOffsetRaw = cameraOffsetRaw * 0.95f;
            }
            if (cameraOffsetRaw.magnitude <= minOffset)
            {
                cameraOffsetRaw = cameraOffsetRaw * 1.05f;
            }
        }

        if (Mode.mode == "3D")
        {
            targetPos = Player3D.position + cameraOffset;
            targetRot = defaultRot;
        }
        else
        {
            targetPos = Cam2DPos.position;
            targetRot = Cam2DPos.rotation;
        }

        transform.position = Vector3.Lerp(transform.position, targetPos, smoothness);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, rotSmoothness);
    }
}
