using UnityEngine;

public class PaintingZoomAndRotate : MonoBehaviour
{
    private float zoomSpeed = 1.0f;
    private float rotateSpeed = 50.0f;
    public Renderer paintingRenderer;

    public void ZoomMode()
    {
        // Disable other renderers in the scene
        Renderer[] allRenderers = FindObjectsOfType<Renderer>();
        foreach (Renderer renderer in allRenderers)
        {
            if (renderer != paintingRenderer)
                renderer.enabled = false;
        }
    }

    public void HandleZoomAndRotate()
    {
        // Xử lý thao tác Zoom
        float zoomInput = -Input.GetAxis("Mouse ScrollWheel");
        transform.localScale += new Vector3(zoomInput, zoomInput, zoomInput) * zoomSpeed;

        // Xử lý thao tác Rotate
        float rotateInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, rotateInput * rotateSpeed * Time.deltaTime);
    }
    public void ZoomIn()
    {
        // Xử lý thao tác ZoomIn
        float zoomInput = 0.5f;
        transform.localScale += new Vector3(zoomInput, zoomInput, 0) * zoomSpeed;
    }

    public void ZoomOut()
    {
        // Xử lý thao tác ZoomOut
        float zoomInput = -0.5f;
        transform.localScale += new Vector3(zoomInput, zoomInput, 0) * zoomSpeed;
    }

    public void RotateLeft()
    {
        // Xử lý thao tác RotateLeft
        float rotateInput = -10f;
        transform.Rotate(Vector3.up, rotateInput * rotateSpeed * Time.deltaTime);
    }

    public void RotateRight()
    {
        // Xử lý thao tác RotateRight
        float rotateInput = 10f;
        transform.Rotate(Vector3.up, rotateInput * rotateSpeed * Time.deltaTime);
    }
}