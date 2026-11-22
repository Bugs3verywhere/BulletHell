using UnityEngine;

[RequireComponent(typeof(Camera))]
public class SquareCameraViewport : MonoBehaviour
{
    private Camera cam;
    private int lastWidth;
    private int lastHeight;

    void Awake()
    {
        cam = GetComponent<Camera>();
        ApplySquareViewport();
    }

    void Update()
    {
        if (Screen.width != lastWidth || Screen.height != lastHeight)
        {
            ApplySquareViewport();
        }
    }

    public void ApplySquareViewport()
    {
        lastWidth = Screen.width;
        lastHeight = Screen.height;

        if (lastWidth <= 0 || lastHeight <= 0) return;

        if (lastWidth > lastHeight)
        {
            float scaleWidth = (float)lastHeight / lastWidth;
            cam.rect = new Rect((1f - scaleWidth) * 0.5f, 0f, scaleWidth, 1f);
        }
        else
        {
            float scaleHeight = (float)lastWidth / lastHeight;
            cam.rect = new Rect(0f, (1f - scaleHeight) * 0.5f, 1f, scaleHeight);
        }
    }
}