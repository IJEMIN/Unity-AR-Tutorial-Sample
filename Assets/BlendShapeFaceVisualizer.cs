using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARKit;

public class BlendShapeFaceVisualizer : MonoBehaviour
{
    public SkinnedMeshRenderer faceMeshRenderer;

    ARKitFaceSubsystem arKitFaceSubsystem;

    Dictionary<ARKitBlendShapeLocation, int> faceArkitBlendShapeMappingIndex;

    ARFace arFace;

    void Awake()
    {
        arFace = GetComponent<ARFace>();
        CreateFreatureBlendShapeMapping();
    }

    void CreateFreatureBlendShapeMapping()
    {
        faceArkitBlendShapeMappingIndex = new Dictionary<ARKitBlendShapeLocation, int>();

        faceArkitBlendShapeMappingIndex[ARKitBlendShapeLocation.MouthLeft]
            = faceMeshRenderer.sharedMesh.GetBlendShapeIndex("jemin_mouse_left");

        faceArkitBlendShapeMappingIndex[ARKitBlendShapeLocation.EyeBlinkLeft]
            = faceMeshRenderer.sharedMesh.GetBlendShapeIndex("jemin_eyeblink_left");
    }

    void Update()
    {
        UpdateFace();
    }
    void UpdateFace()
    {
        var blendShapes = arKitFaceSubsystem.GetBlendShapeCoefficients(arFace.trackableId, Unity.Collections.Allocator.Temp);

        foreach (var blendShape in blendShapes)
        {
            faceMeshRenderer.SetBlendShapeWeight(
                faceArkitBlendShapeMappingIndex[blendShape.blendShapeLocation]
                , blendShape.coefficient);
        }
    }
}
