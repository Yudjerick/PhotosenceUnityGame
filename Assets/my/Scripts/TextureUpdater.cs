using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureUpdater : MonoBehaviour
{
    public RenderTexture cameraImage;
    private Renderer rend;
    public string texturePropetrtyID;
    [SerializeField] private Texture2D photo;
    Rect rectReadPicture;
    void Start()
    {
        photo = new Texture2D(512, 512);
        rend = GetComponent<Renderer>();
        //rend.material.SetTexture(texturePropetrtyID, photo);

        rectReadPicture = new Rect(0, 0, 512, 512);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {

            photo = new Texture2D(512, 512);

            // ofc you probably don't have a class that is called CameraController :P
            //Camera activeCamera = CameraController.getActiveCamera();

            // Initialize and render
            //RenderTexture rt = new RenderTexture(width, height, 24);
            //activeCamera.targetTexture = rt;
            //activeCamera.Render();
            RenderTexture.active = cameraImage;

            // Read pixels
            photo.ReadPixels(rectReadPicture, 0, 0);
            photo.Apply();
            rend.material.SetTexture(texturePropetrtyID, photo);


            // Clean up;

        }
    }
}
