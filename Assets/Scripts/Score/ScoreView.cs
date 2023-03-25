using UnityEngine;
using TMPro;
public class ScoreView : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreLabel;

    private int _score;
    public void OnPassedPipe()
    {
        _score++;
        _scoreLabel.text = _score.ToString();
    }
}
