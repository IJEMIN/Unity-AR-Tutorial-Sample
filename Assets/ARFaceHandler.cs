using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARFaceHandler : MonoBehaviour
{
    public ARFaceManager faceManager;
    // Start is called before the first frame update
    void Start()
    {
        faceManager.facesChanged += OnFaceChanaged;
    }

    private void OnFaceChanaged(ARFacesChangedEventArgs args)
    {
        // 얼굴에 대한 변경사항이 감지되었을때
    }
}
