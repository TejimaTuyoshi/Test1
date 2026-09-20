using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class ScoreData
{
    public int scoreNum;//総合評価
    public int maxCombo;//連続成功率
    public int addScore;//一回の増加量
}

public class ScoreUI : MonoBehaviour
{
    [SerializeField] Text _scoreText;
    [SerializeField] SaveData _saveData;
    int _score;
    void Start()
    {
        _score = 0;
    }

    void Update()
    {
        _scoreText.text = $"{_score}点";
    }

    private void FixedUpdate()
    {
        _score = _saveData.data.scoreNum;
    }

    public void ScoreUp()//点数上昇
    {
        _saveData.data.scoreNum += _saveData.data.addScore;
    }

    public void CostUp()//一回の上昇量増加
    {
        _saveData.data.addScore++;
    }

    public void ResetScore()//データ数値初期化
    {
        _saveData.data.addScore = 0;
        _saveData.data.maxCombo = 0;
        _saveData.data.scoreNum = 0;
    }
}
