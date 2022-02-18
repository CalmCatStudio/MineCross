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
        model.OnFieldRestartButton.SetActive(true);

        string levelAsText = currentLevel.ToString();
        model.LevelText.text = $"Level {levelAsText}";
    }

    public void EnableWinScreen()
    {
        model.WinCavas.SetActive(true);
        model.OnFieldRestartButton.SetActive(false);
    }

    public void EnableLoseScreen()
    {
        model.LoseCanvas.SetActive(true);
        model.OnFieldRestartButton.SetActive(false);
    }
}
