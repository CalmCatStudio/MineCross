using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera = null;
    [SerializeField]
    private GameController game = null;
    public Vector2 MousePosition { get; private set; }

    private RaycastHit2D hit;

    private void Awake()
    {
        if (mainCamera == null || game == null)
        {
            ErrorMessages.NullMessage(gameObject);
        }
    }

    public void OnSetPosition(InputAction.CallbackContext context)
    {
        // This prevents an error when changing scenes, or exiting the editor.
        if (mainCamera != null)
        {
            MousePosition = mainCamera.ScreenToWorldPoint(context.ReadValue<Vector2>());
        }
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if (context.canceled)
        {
            Vector2Int mousePosition = Vector2Int.RoundToInt(MousePosition);
            CheckForRayCastHit(mousePosition);

            if (hit)
            {
                game.Clicked(mousePosition);
            }
        }
    }

    /// <summary>
    /// Acts like a mouseclick, and will return true if it hits something
    /// it assigns the hit to a global variable name hit
    /// </summary>
    private bool CheckForRayCastHit(Vector2 mousePosition)
    {
        bool hitDetect;
        hit = Physics2D.Raycast(mousePosition, Vector3.forward, 100);
        if (hit)
        {
            hitDetect = true;
        }
        else
        {
            hitDetect = false;
        }
        return hitDetect;
    }
}
