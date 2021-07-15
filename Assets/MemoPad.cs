using UnityEngine;
using UnityEngine.UI;

public class MemoPad : MonoBehaviour
{
    [SerializeField]
    private Toggle emptyToggle = null;
    [SerializeField]
    private Toggle crossToggle = null;

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
        bool state = !crossToggle.isOn;

        crossToggle.isOn = state;
        emptyToggle.isOn = state;
    }
}

public enum MemoState
{
    None,
    Cross,
    Empty,
    Both
}