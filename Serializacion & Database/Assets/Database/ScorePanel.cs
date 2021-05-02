using UnityEngine;
using TMPro;

public class ScorePanel : MonoBehaviour
{
    [Header("UI Settings")]
    [SerializeField, Tooltip("Score input field.")]
    private TMP_InputField _score;

    private DBAdmin _dataBase;
    private string _username;

    public void Init(DBAdmin db, string user)
    {
        _dataBase = db;
        _username = user;

        GetScore();
    }

    public void SetScore()
    {
        _dataBase.SetScore(_username, _score.text);
    }

    public void GetScore()
    {
        _dataBase.GetScore(_username, GetScoreSucceed, GetScoreFailed);
    }

    void GetScoreSucceed(string message)
    {
        Debug.Log($"Bruto: {message}");

        string[] rows = message.Split('\n');

        string score = rows[1];
        _score.text = score;
    }

    void GetScoreFailed(string message)
    {
        Debug.Log(message);
    }

    public void DeleteScore()
    {
        _dataBase.DeleteScore(_username, DeleteScoreSucceed);
    }

    void DeleteScoreSucceed(string message)
    {
        Debug.Log($"Score deleted: {message}");
        _score.text = "0";
    }
}
