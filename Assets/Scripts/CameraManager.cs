using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager instance;

    // Dictionary to map enum values to Cinemachine virtual cameras
    public Dictionary<CameraType, CinemachineVirtualCamera> cameraDictionary = new Dictionary<CameraType, CinemachineVirtualCamera>(){};
    // Reference to the currently active virtual camera private
    CinemachineVirtualCamera currentCamera;
    public CinemachineVirtualCamera playerCamera;
    public CinemachineVirtualCamera bossCamera;
    public Transform player;
    

    public List <CinemachineVirtualCamera> cameras;


    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }

        cameraDictionary.Add(CameraType.PlayerCamera, playerCamera);
        cameraDictionary.Add(CameraType.BossCamera, bossCamera);
    }

    void Start() { SwitchCamera(CameraType.PlayerCamera); }
    // Function to switch between virtual cameras using the enum
    public void SwitchCamera(CameraType newCameraType)
    {
        // Disable the current camera
        if (currentCamera != null) { currentCamera.gameObject.SetActive(false); }
        // Enable the new camera based on the enum
        if (cameraDictionary.ContainsKey(newCameraType))
        {
            currentCamera = cameraDictionary[newCameraType];
            currentCamera.Follow = player.transform;
            currentCamera.LookAt = player.transform;
            currentCamera.gameObject.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Camera of type " + newCameraType + " not found in the dictionary.");
        }
    }
}
// Enum to represent different cameras
public enum CameraType
{
    PlayerCamera, BossCamera 
}
