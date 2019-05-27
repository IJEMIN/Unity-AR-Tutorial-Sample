using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ApplyARLightAmbient : MonoBehaviour
{
    private Light directionalLight;
    public ARCameraManager arCameraManager;

    void Start()
    {
        directionalLight = GetComponent<Light>();

        arCameraManager.frameReceived += FrameChanged;
    }
    private void FrameChanged(ARCameraFrameEventArgs args)
    {
        if (args.lightEstimation.averageBrightness.HasValue)
        {
            directionalLight.intensity = args.lightEstimation.averageBrightness.Value;
        }

        if (args.lightEstimation.averageColorTemperature.HasValue)
        {
            directionalLight.colorTemperature = args.lightEstimation.averageBrightness.Value;
        }

        if (args.lightEstimation.colorCorrection.HasValue)
        {
            directionalLight.color = args.lightEstimation.colorCorrection.Value;
        }
    }

}
