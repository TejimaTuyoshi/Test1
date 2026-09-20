using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] Text scoreText;
    int score;
    void Start()
    {
        score = 0;
    }

    void Update()
    {
        scoreText.text = $"{score}";
    }

    void ScoreUp()
    {
        score++;
    }
}
