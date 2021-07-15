using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileView : MonoBehaviour
{
    [Tooltip("The sprites MUST be in the order: Bomb, Empty, Good")]
    [SerializeField]
    private Sprite[] uncoveredSprites = new Sprite[2];
    [SerializeField]
    private SpriteRenderer revealedRenderer = null;

    [SerializeField]
    private SpriteRenderer crossMemoRenderer = null;
    [SerializeField]
    private SpriteRenderer emptyMemoRenderer = null;


    public void Init(TileValue value)
    {
        if (revealedRenderer == null || crossMemoRenderer == null || emptyMemoRenderer == null)
        {
            ErrorMessages.NullMessage(gameObject);
        }

        revealedRenderer.sprite = uncoveredSprites[(int)value];
        revealedRenderer.gameObject.SetActive(false);
        TurnOffAllMemos();
    }

    public void RevealTile()
    {
        TurnOffAllMemos();
        revealedRenderer.gameObject.SetActive(true);
    }

    public void ToggleCrossMemo()
    {
        // Sets the objects activity to what it currently isn't
        crossMemoRenderer.gameObject.SetActive(!crossMemoRenderer.gameObject.activeInHierarchy);
    }

    public void ToggleEmptyMemo()
    {
        emptyMemoRenderer.gameObject.SetActive(!emptyMemoRenderer.gameObject.activeInHierarchy);
    }

    public void ToggleBothMemos()
    {
        // We want to line up the memo toggles; So we use one of the objects to decide the state
        bool memoState = !crossMemoRenderer.gameObject.activeInHierarchy;

        emptyMemoRenderer.gameObject.SetActive(memoState);
        crossMemoRenderer.gameObject.SetActive(memoState);
    }

    private void TurnOffAllMemos()
    {
        crossMemoRenderer.gameObject.SetActive(false);
        emptyMemoRenderer.gameObject.SetActive(false);
    }
}
