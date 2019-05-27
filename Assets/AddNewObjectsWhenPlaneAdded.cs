using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR;

public class AddNewObjectsWhenPlaneAdded : MonoBehaviour
{
    public GameObject spawnTarget;
    public ARPlaneManager arPlaneManager;
    private Dictionary<TrackableId, GameObject> spawnedObjects;

    void Start()
    {
        arPlaneManager.planesChanged += SpawnObjects;
    }

    private void SpawnObjects(ARPlanesChangedEventArgs args)
    {
        List<ARPlane> addedPlanes = args.added;

        if (addedPlanes.Count > 0)
        {
            foreach (ARPlane plane in addedPlanes)
            {
                if (plane.alignment != PlaneAlignment.HorizontalUp) continue;

                Vector3 spawnPosition = plane.center
                    + Random.Range(0, plane.boundary[0].x) * plane.transform.right +
                    Random.Range(0, plane.boundary[0].y) * plane.transform.forward;

                GameObject instance = Instantiate(spawnTarget, spawnPosition, plane.transform.rotation);
                spawnedObjects.Add(plane.trackableId, instance);
            }
        }

        List<ARPlane> removedPlanes = args.removed;

        if (removedPlanes.Count > 0)
        {
            foreach (ARPlane plane in removedPlanes)
            {
                GameObject destoryTarget = spawnedObjects[plane.trackableId];
                Destroy(destoryTarget);
            }
        }


        List<ARPlane> updatedPlanes = args.updated;

        if (updatedPlanes.Count > 0)
        {
            foreach (ARPlane plane in updatedPlanes)
            {
                // 상태가 갱신된 평면에 대해서 실행할 어떤 처리...
            }
        }
    }
}
