using UnityEngine;
using TMPro;

public class ScorePanel : MonoBehaviour
{
    [Header("UI Settings")]
    [SerializeField, Tooltip("Score input field.")]
    private TMP_InputField _score;

    private DBAdmin _dataBase = default;
    private string _username = default;
    private TMP_Text _message = default;

    public void Init(DBAdmin db, string user, TMP_Text message)
    {
        _dataBase = db;
        _username = user;
        _message = message;

        GetScore();
    }
    public void OnClose()
    {
        _score.text = "";

    }
    public void SetScore()
    {
        _dataBase.SetScore(_username, _score.text, SetScoreSucceed, SetScoreFailed);
    }
    void SetScoreSucceed(string message)
    {
        _message.text = message;
    }
    void SetScoreFailed(string message)
    {
        _message.text = message;
    }

    public void GetScore()
    {
        _dataBase.GetScore(_username, GetScoreSucceed, GetScoreFailed);
    }

    void GetScoreSucceed(string message)
    {
        string[] rows = message.Split('\n');

        string score = rows[1];
        _score.text = score;
        _message.text = "";
    }

    void GetScoreFailed(string message)
    {
        _message.text = message;
    }

    public void DeleteScore()
    {
        _dataBase.DeleteScore(_username, DeleteScoreSucceed, DeleteScoreFailed);
    }

    void DeleteScoreSucceed(string message)
    {
        _message.text = "Score Deleted";
        _score.text = "0";
    }
    void DeleteScoreFailed(string message)
    {
        _message.text = message;
    }
}
