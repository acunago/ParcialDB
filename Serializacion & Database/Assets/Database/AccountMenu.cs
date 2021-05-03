using System.Collections;
using System.Collections.Generic;
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

    private string _username;

    public void AccountLogged(string user)
    {
        _username = user;
        _welcome.text = $"Welcome {_username}!";

        _score.Init(_dataBase, _username);
        _friend.Init(_dataBase, _username);
    }

    public void AccountLogOut()
    {
        _username = "";

        _mainScreen.SetActive(true);
        _friend.OnClose();
        _myScreen.SetActive(false);
    }
}
