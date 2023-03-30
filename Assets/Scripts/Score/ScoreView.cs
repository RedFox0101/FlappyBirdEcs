using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private List<ScoreElement> _scoreElements;

    private int _score;
    private int _indexElement;
    [ContextMenu("UpdateScore")]
    public void AddScore()
    {
        _score++;
        _scoreElements[_indexElement].UpdateValue();
    }
    public void DeactivareScoreElements()
    {
        _scoreElements.ForEach(element => element.gameObject.SetActive(false));
    }

    private void OnEnable()
    {
        foreach (var scoreElement in _scoreElements)
        {
            scoreElement.WentOutOfArray += UpdateScore;
        }
    }

    private void OnDisable()
    {
        foreach (var scoreElement in _scoreElements)
        {
            scoreElement.WentOutOfArray -= UpdateScore;
        }
    }

    private void UpdateScore(ScoreElement element)
    {
        int index = _scoreElements.IndexOf(element);
        if (index + 1 > _scoreElements.Count) return;

        if (index == 0)
        {
            AddNumber();
            _scoreElements[index].UpdateValue();
        }
        else
        {
            _scoreElements[index-1].UpdateValue();
            if (_scoreElements[index-1].Value > 9)
            {
                AddNumber();
            }
        }
    }

    private void AddNumber()
    {
        _indexElement++;
        _scoreElements[_indexElement].gameObject.SetActive(true);
    }
}
