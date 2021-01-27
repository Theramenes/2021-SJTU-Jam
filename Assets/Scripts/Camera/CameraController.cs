using System;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    public FloatVariableSO MovementSpeed;
    public FloatVariableSO MovementLerpSpeed;
    public FloatVariableSO ZoomSpeed;

    public Transform CameraTransform;
    public CinemachineVirtualCamera PlayerControlCamera;

    private Vector3 newPosition;
    private Vector3 dragStartPosition;
    private Vector3 dragCurrentPosition;

    [Serializable]
    public class MoveAxis
    {
        public KeyCode Positive;
        public KeyCode Negative;

        public MoveAxis(KeyCode positive, KeyCode negative)
        {
            Positive = positive;
            Negative = negative;
        }

        public static implicit operator float(MoveAxis axis)
        {
            return (Input.GetKey(axis.Positive) ? 1.0f : 0.0f) - (Input.GetKey(axis.Negative) ? 1.0f : 0.0f);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        newPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        HandleMouseInput();
        //HandleKeyMovementInput();
        cameraMove();
    }


    void cameraMove()
    {
        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * MovementLerpSpeed.Value);
        CameraTransform.localPosition = Vector3.Lerp(CameraTransform.localPosition, newPosition,
            Time.deltaTime * MovementLerpSpeed.Value);
    }


    void HandleMouseInput()
    {
        float enter;
        Plane plane = new Plane(Vector3.back, Vector3.zero);
        Ray ray;

        if (Input.mouseScrollDelta.y != 0)
        {
            PlayerControlCamera.m_Lens.OrthographicSize += ZoomSpeed.Value * Input.mouseScrollDelta.y;
            //newZoomPosition += GetCameraZoomNormal() * ZoomSpeed.Value * Input.mouseScrollDelta.y;
            //Debug.Log("mouseScrollDelta and newZoomPosition:" + Input.mouseScrollDelta.y + newZoomPosition);
        }

        if (Input.GetMouseButtonDown(2))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (plane.Raycast(ray, out enter))
            {
                dragStartPosition = ray.GetPoint(enter);
            }

            Debug.Log("dragStartPosition:" + dragStartPosition);
        }
        if (Input.GetMouseButton(2))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (plane.Raycast(ray, out enter))
            {
                dragCurrentPosition = ray.GetPoint(enter);
                newPosition = transform.position - (dragCurrentPosition - dragStartPosition);
            }

            Debug.Log("dragCurrentPosition:" + dragCurrentPosition);
        }
    }

    //Vector3 GetCameraZoomNormal()
    //{
    //    float cameraRotationXRad = CameraTransform.eulerAngles.x * Mathf.Deg2Rad;
    //    float cameraRotationYRad = CameraTransform.eulerAngles.y * Mathf.Deg2Rad;

    //    Vector3 zoomDirectionNormal = new Vector3(Mathf.Cos(cameraRotationXRad) * Mathf.Sin(cameraRotationYRad),
    //        -Mathf.Sin(cameraRotationXRad),
    //        Mathf.Cos(cameraRotationXRad) * Mathf.Cos(cameraRotationYRad));
    //    Debug.Log("Angles:" + CameraTransform.eulerAngles.x + " " + CameraTransform.eulerAngles.y);
    //    Debug.Log("cameraTransform:" + Mathf.Sin(cameraRotationXRad) + " " + Mathf.Sin(cameraRotationYRad));
    //    Debug.Log("cameraZoom:" + zoomDirectionNormal);
    //    return zoomDirectionNormal;
    //}


}
