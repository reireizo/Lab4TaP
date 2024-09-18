using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CinemachineImpulseSource))]
public class CameraEffect : MonoBehaviour
{
    CinemachineImpulseSource cinemachineImpulse;

    // Start is called before the first frame update
    void OnEnable ()
    {
        //BigMeteor.BigMeteorDestroyed += ApplyScreenShake;
    }

    // Update is called once per frame
    void OnDisable()
    {
        //BigMeteor.BigMeteorDestroyed -= ApplyScreenShake;
    }

    private void Awake()
    {
        cinemachineImpulse = GetComponent<CinemachineImpulseSource>();
    }

    public void ApplyScreenShake()
    {
        cinemachineImpulse.GenerateImpulse();
    }
}
