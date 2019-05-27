using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class TrackedObjectHandler : MonoBehaviour
{
    public ARTrackedObjectManager trackedObjectManager;
    // Start is called before the first frame update
    void Start()
    {
        trackedObjectManager.trackedObjectsChanged += OnTrackedObjectsChanged;
    }

    private void OnTrackedObjectsChanged(ARTrackedObjectsChangedEventArgs args)
    {
        List<ARTrackedObject> trackedObjects = args.added;

        foreach (ARTrackedObject trackedObject in trackedObjects)
        {
            if (trackedObject.referenceObject.name == "cube")
            {
                trackedObject.GetComponent<Renderer>().material.color = Color.green;
            }
        }
    }
}
