using UnityEngine;
using UnityEngine.UI;

public class MemoPad : MonoBehaviour
{
    [SerializeField]
    private Toggle emptyToggle = null;
    [SerializeField]
    private Toggle crossToggle = null;

    [SerializeField]
    private AudioSource audioSource = null;

    public MemoState State
    {
        get
        {
            if (emptyToggle.isOn && crossToggle.isOn)
            {
                return MemoState.Both;
            }
            else if (emptyToggle.isOn)
            {
                return MemoState.Empty;
            }
            else if (crossToggle.isOn)
            {
                return MemoState.Cross;
            }
            else
            {
                return MemoState.None;
            }
        }
    }

    public void ToggleMemos()
    {
        bool toggleState = false;

        // If either Toggle is turned off
        if (!crossToggle.isOn || !emptyToggle.isOn)
        {
            // Then we want to turn them both on.
            toggleState = true;
        }
        else /* Both toggles are on */
        {
            // Turn them off
            toggleState = false;
        }
        crossToggle.isOn = toggleState;
        emptyToggle.isOn = toggleState;
    }
}

public enum MemoState
{
    None,
    Cross,
    Empty,
    Both
}