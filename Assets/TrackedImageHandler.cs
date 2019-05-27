using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class TrackedImageHandler : MonoBehaviour
{
    public ARTrackedImageManager trackedImageManager;

    void Start()
    {
        trackedImageManager.trackedImagesChanged += OnTrackedImageChanged;
    }

    void OnTrackedImageChanged(ARTrackedImagesChangedEventArgs args)
    {
        List<ARTrackedImage> addedImages = args.added;
        List<ARTrackedImage> removedImages = args.removed;
        // List<ARTrackedImage> updatedImages = args.updated;

        foreach (ARTrackedImage image in addedImages)
        {
            if (image.referenceImage.name == "logo")
            {
                image.GetComponent<Renderer>().material.color = Color.red;
            }
            else if (image.referenceImage.name == "qr")
            {
                image.GetComponent<Renderer>().material.color = Color.blue;
            }

            if (image.trackingState != TrackingState.None)
            {
                image.GetComponent<Renderer>().enabled = true;
            }
            else
            {
                image.GetComponent<Renderer>().enabled = false;
            }
        }
    }
}
