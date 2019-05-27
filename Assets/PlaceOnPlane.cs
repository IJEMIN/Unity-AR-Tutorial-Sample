using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaceOnPlane : MonoBehaviour
{
    public ARRaycastManager arRaycaster;
    public GameObject spawnPrefab;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    bool isActive = false;

    void Awake()
    {
        ARSession.stateChanged += OnStateChanged;
    }

    void OnStateChanged(ARSessionStateChangedEventArgs args)
    {
        Debug.Log(args.state);

        if (args.state == ARSessionState.Unsupported)
        {
            Application.Quit();
            return;
        }

        if (args.state == ARSessionState.Ready)
        {
            isActive = true;
        }
        else
        {
            isActive = false;
        }
    }

    void Update()
    {
        if (!isActive) return;


        if (Input.touchCount == 0)
        {
            return;
        }

        Touch touch = Input.GetTouch(0);

        if (touch.phase != TouchPhase.Began)
        {
            return;
        }

        if (arRaycaster.Raycast(touch.position, hits, TrackableType.PlaneWithinBounds))
        {
            Pose hitPose = hits[0].pose;

            if (hits[0].hitType == TrackableType.Image)
            {
                // 레이를 맞은 오브젝트가 이미지라면 ~~
            }


            Instantiate(spawnPrefab, hitPose.position, hitPose.rotation);
        }
    }
}
