using UnityEngine;
using UnityEngine.UI;

public class UIModel : MonoBehaviour
{
    [SerializeField]
    private GameObject winCanvas = null;
    public GameObject WinCavas { get { return winCanvas; } }

    [SerializeField]
    private GameObject loseCanvas = null;
    public GameObject LoseCanvas { get { return loseCanvas; } }

    [SerializeField]
    private Text levelText = null;
    public Text LevelText { get { return levelText; } }

    [SerializeField]
    private GameObject onFieldRestartButton = null;
    public GameObject OnFieldRestartButton { get { return onFieldRestartButton; } }
}
