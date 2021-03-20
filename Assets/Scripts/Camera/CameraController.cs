using System;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{    [Header("Cameras")]
    public Transform CameraTransform;
    public CinemachineVirtualCamera PlayerControlCamera;
    public CinemachineVirtualCamera DashFollowCamera;

    [Header("Camera Movement Parameters")]
    public FloatReference MovementSpeed;
    public FloatReference MovementLerpSpeed;
    public FloatReference ZoomSpeedControl;

    public FloatReference ZoomLerpSpeed;
    public FloatReference OrgaCameraOrthoSize;
    public FloatReference ZoomSpeedRuntime;

    [Header("Character Movement Data")]
    public CharacterMovementStateSO MovementState;

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
        CameraMove();
        RuntimeCameraZoom();
    }


    private void CameraMove()
    {
        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * MovementLerpSpeed.Value);
        CameraTransform.localPosition = Vector3.Lerp(CameraTransform.localPosition, newPosition,
            Time.deltaTime * MovementLerpSpeed.Value);
    }


    private void HandleMouseInput()
    {
        float enter;
        Plane plane = new Plane(Vector3.back, Vector3.zero);
        Ray ray;

        if (Input.mouseScrollDelta.y != 0)
        {
            PlayerControlCamera.m_Lens.OrthographicSize -= ZoomSpeedControl.Value * Input.mouseScrollDelta.y;
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

    private void RuntimeCameraZoom()
    {
        float curOrthoSize = DashFollowCamera.m_Lens.OrthographicSize;
        if (DashFollowCamera.gameObject.activeSelf)
            DashFollowCamera.m_Lens.OrthographicSize = Mathf.Lerp(curOrthoSize,OrgaCameraOrthoSize.Value +
                ZoomSpeedRuntime.Value * MovementState.CharacterSpeed.Value, ZoomLerpSpeed.Value); 
    }


    public void DashStartCameraSwitch()
    {
        DashFollowCamera.gameObject.SetActive(true);
        PlayerControlCamera.gameObject.SetActive(false);
    }

    public void DashCameraZoomIn()
    {
        DashFollowCamera.m_Lens.OrthographicSize = OrgaCameraOrthoSize;
    }


}
