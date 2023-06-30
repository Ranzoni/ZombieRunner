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

    bool isZoomOut;

    void Update()
    {
        SetZoom();
    }

    void SetZoom()
    {
        if (!Input.GetMouseButtonDown(1))
            return;

        if (isZoomOut)
            SetZoomOut();
        else
            SetZoomIn();
    }

    void SetZoomOut()
    {
        fpsCamera.m_Lens.FieldOfView = zoomedOut;
        fpsController.RotationSpeed = zoomedOutSensitivy;
        isZoomOut = false;
    }

    void SetZoomIn()
    {
        fpsCamera.m_Lens.FieldOfView = zoomedIn;
        fpsController.RotationSpeed = zoomedInSensitivy;
        isZoomOut = true;
    }
}
