using UnityEngine;

public class PortalTextureSetup : MonoBehaviour
{

    public Camera cameraA;
    public Camera cameraB; // Reference to the camera that will render the portal view

    public Material cameraMatA;
    public Material cameraMatB; // Reference to the material that will be used for the portal texture

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (cameraA.targetTexture != null)
        {
            cameraA.targetTexture.Release();
        }
        cameraA.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);

        cameraMatA.mainTexture = cameraA.targetTexture;

        if (cameraB.targetTexture != null)
        {
            cameraB.targetTexture.Release();
        }
        cameraB.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);

        cameraMatB.mainTexture = cameraB.targetTexture;

    }


}
