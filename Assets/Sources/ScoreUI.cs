using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private PlayerScore _playerScore;

    private TextMeshProUGUI _scoreTMPro;

    private void Awake()
    {
        _scoreTMPro = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        _playerScore.ScoreUpdated += UpdateText;
    }

    private void UpdateText()
    {
        _scoreTMPro.text = _playerScore.Score.ToString();
    }
}