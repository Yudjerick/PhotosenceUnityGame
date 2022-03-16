using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureUpdater : MonoBehaviour
{
    public RenderTexture cameraImage;
    private Renderer rend;
    public string textureName;
    private string texturePropetrtyID;
    [SerializeField] private Texture2D photo;
    Rect rectReadPicture;
    private int rtW;
    private int rtH;
    void Start()
    {

        rtH = cameraImage.height;
        rtW = cameraImage.width;
        photo = new Texture2D(rtW, rtH);
        rend = GetComponent<Renderer>();

        rectReadPicture = new Rect(0, 0, rtW, rtH);

        if(textureName == "noisy")
        {
            texturePropetrtyID = "Texture2D_430c8df42ade4ad68bd8a0df74f8792b";
        }
        if (textureName == "retro")
        {
            texturePropetrtyID = "Texture2D_fdc1de0df2684f";
        }
        if (textureName == "digital")
        {
            texturePropetrtyID = "Texture2D_5fe93edfa3f34564bbab352ec03a3a56";
        }
        if (textureName == "abstract")
        {
            texturePropetrtyID = "Texture2D_dcceaa38629e48e6acea2d244fca997f";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && Mode.mode == "3D")
        {

            photo = new Texture2D(rtW, rtH);

            
            RenderTexture.active = cameraImage;

            // Read pixels
            photo.ReadPixels(rectReadPicture, 0, 0);
            photo.Apply();
            rend.material.SetTexture(texturePropetrtyID, photo);

        }
    }
}
