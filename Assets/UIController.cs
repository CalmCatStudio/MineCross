using UnityEngine;

[RequireComponent(typeof(UIModel))]
public class UIController : MonoBehaviour
{
    [SerializeField]
    private UIModel model = null;

    public void Init()
    {
        if (model == null)
        {
            ErrorMessages.NullMessage(gameObject);
        }
    }

    public void StartNextRound(int currentLevel)
    {
        model.WinCavas.SetActive(false);
        model.LoseCanvas.SetActive(false);

        string levelAsText = currentLevel.ToString();
        model.LevelText.text = $"Level {levelAsText}";
    }

    public void EnableWinCanvas()
    {
        model.WinCavas.SetActive(true);
    }

    public void EnableLoseCanvas()
    {
        model.LoseCanvas.SetActive(true);
    }
}
