using UnityEngine;
using TMPro;

public class AccountMenu : MonoBehaviour
{
    [SerializeField, Tooltip("Data base intance.")]
    private DBAdmin _dataBase;
    [SerializeField, Tooltip("Score Instance.")]
    private ScorePanel _score;
    [SerializeField, Tooltip("Friend Instance.")]
    private FriendPanel _friend;

    [Header("UI Settings")]
    [SerializeField, Tooltip("My screen.")]
    private GameObject _myScreen;
    [SerializeField, Tooltip("Main screen.")]
    private GameObject _mainScreen;
    [SerializeField, Tooltip("Welcome text.")]
    private TMP_Text _welcome;
    [SerializeField, Tooltip("Message text.")]
    private TMP_Text _message;

    private string _username = default;

    public void AccountLogged(string user)
    {
        _username = user;
        _welcome.text = $"Welcome {_username}!";

        _score.Init(_dataBase, _username, _message);
        _friend.Init(_dataBase, _username, _message);
    }

    public void AccountLogOut()
    {
        _username = "";
        _mainScreen.SetActive(true);
        _score.OnClose();
        _friend.OnClose();
        _myScreen.SetActive(false);
    }
}
