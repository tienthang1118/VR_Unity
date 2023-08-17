using UnityEngine;
using UnityEngine.UI;

public class ButtonClickHandler : MonoBehaviour
{
    public GameObject painting;

    private bool isZoomAndRotateEnabled = false;

    // Lưu trữ trạng thái trước đó của chức năng Zoom và Rotate
    private bool wasZoomAndRotateEnabled = false;

    public void OnButtonClick()
    {
        // Kích hoạt chức năng Zoom và Rotate cho tranh
        isZoomAndRotateEnabled = !isZoomAndRotateEnabled;

        // Nếu chức năng được kích hoạt lần đầu tiên hoặc được kích hoạt từ trạng thái tắt
        if (isZoomAndRotateEnabled && !wasZoomAndRotateEnabled)
        {
            // Lưu trạng thái trước đó của chức năng Zoom và Rotate
            wasZoomAndRotateEnabled = true;
        }
        // Nếu chức năng được tắt lần đầu tiên hoặc được tắt từ trạng thái kích hoạt
        else if (!isZoomAndRotateEnabled && wasZoomAndRotateEnabled)
        {
            // Tắt chức năng Zoom và Rotate
            wasZoomAndRotateEnabled = false;

            // Hiển thị lại tất cả các Renderer trong cảnh
            Renderer[] allRenderers = FindObjectsOfType<Renderer>();
            foreach (Renderer renderer in allRenderers)
            {
                renderer.enabled = true;
            }
        }
    }

    private void Update()
    {
        // Xử lý sự kiện khi người dùng nhấn nút thoát (ví dụ: Back button trên điện thoại)
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Tắt chức năng Zoom và Rotate
            isZoomAndRotateEnabled = false;
            
            // Hiển thị lại tất cả các Renderer trong cảnh
            Renderer[] allRenderers = FindObjectsOfType<Renderer>();
            foreach (Renderer renderer in allRenderers)
            {
                renderer.enabled = true;
            }
        }

        // Xử lý thao tác Zoom và Rotate nếu chức năng đã được kích hoạt
        if (isZoomAndRotateEnabled)
        {
            // Gọi hàm xử lý Zoom và Rotate của tranh (cần viết trong script riêng)
            painting.GetComponent<PaintingZoomAndRotate>().HandleZoomAndRotate();
            painting.GetComponent<PaintingZoomAndRotate>().ZoomMode();
        }
    }
}