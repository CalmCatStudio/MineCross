using DG.Tweening;
using UnityEngine;

public class TileView : MonoBehaviour
{
    [Tooltip("The sprites MUST be in the order: Bomb, Empty, Good, Best")]
    [SerializeField]
    private Sprite[] uncoveredSprites = new Sprite[2];
    [SerializeField]
    private SpriteRenderer pointValueRenderer = null;
    [SerializeField]
    private GameObject innerSquare = null;
    [SerializeField]
    private GameObject crossMemo = null;
    [SerializeField]
    private GameObject emptyMemo = null;

    [SerializeField]
    private float revealSpeed = .8f;

    public void Init(TileValue value)
    {
        if (innerSquare == null || crossMemo == null || emptyMemo == null)
        {
            ErrorMessages.NullMessage(gameObject);
        }
        innerSquare.transform.DORotate(new Vector3(0, 0, 0), .1f);
        pointValueRenderer.sprite = uncoveredSprites[(int)value];

        TurnOffAllMemos();
    }

    public void RevealTile()
    {
        innerSquare.transform.DORotate(new Vector3(0, 180, 0), revealSpeed);
    }

    public void ToggleCrossMemo()
    {
        // Sets the objects activity to what it currently isn't
        crossMemo.SetActive(!crossMemo.activeInHierarchy);
    }

    public void ToggleEmptyMemo()
    {
        emptyMemo.SetActive(!emptyMemo.activeInHierarchy);
    }

    public void ToggleBothMemos()
    {
        bool memoState = false;

        if (!crossMemo.activeInHierarchy || !emptyMemo.activeInHierarchy)
        {
            memoState = true;
        }
        else
        {
            memoState = false;
        }

        emptyMemo.SetActive(memoState);
        crossMemo.SetActive(memoState);
    }

    private void TurnOffAllMemos()
    {
        crossMemo.SetActive(false);
        emptyMemo.SetActive(false);
    }
}
