using Cinemachine;
using StarterAssets;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] float zoomedIn = 10f;
    [SerializeField] float zoomedOut = 10f;
    [SerializeField] float zoomedInSensitivy = .5f;
    [SerializeField] float zoomedOutSensitivy = 1f;
    [SerializeField] CinemachineVirtualCamera fpsCamera;
    [SerializeField] FirstPersonController fpsController;

    bool isZoomIn;

    void OnDisable()
    {
        SetZoomOut();
    }

    void Update()
    {
        if (!Input.GetMouseButtonDown(1))
            return;

        SetZoom();
    }

    void SetZoom()
    {
        if (isZoomIn)
            SetZoomOut();
        else
            SetZoomIn();
    }

    void SetZoomOut()
    {
        fpsCamera.m_Lens.FieldOfView = zoomedOut;
        fpsController.RotationSpeed = zoomedOutSensitivy;
        isZoomIn = false;
    }

    void SetZoomIn()
    {
        fpsCamera.m_Lens.FieldOfView = zoomedIn;
        fpsController.RotationSpeed = zoomedInSensitivy;
        isZoomIn = true;
    }
}
