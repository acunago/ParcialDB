using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class FriendRow : MonoBehaviour
{
    [Header("UI Settings")]
    [SerializeField, Tooltip("Friend name text.")]
    private TMP_Text _name;
    [SerializeField, Tooltip("Status text.")]
    private TMP_Text _status;
    [SerializeField, Tooltip("Delete friend button.")]
    private GameObject _delete;
    [SerializeField, Tooltip("Accept friend button.")]
    private GameObject _accept;
    [SerializeField, Tooltip("Ignore friend button.")]
    private GameObject _ignore;

    private DBAdmin _dataBase;
    private string _username;
    private int _id;
    Action _action;
    public void Init(DBAdmin db, string user, int id, string name, int status, Action myAction)
    {
        _dataBase = db;
        _username = user;
        _id = id;

        _name.text = name;
        _action = myAction;
        switch (status)
        {
            case 0:
                _status.text = "Invited..";
                _delete.SetActive(true);
                _accept.SetActive(false);
                _ignore.SetActive(false);
                break;
            case 1:
                _status.text = "Pending..";
                _delete.SetActive(false);
                _accept.SetActive(true);
                _ignore.SetActive(true);
                break;
            case 2:
                _status.text = "Friends";
                _delete.SetActive(true);
                _accept.SetActive(false);
                _ignore.SetActive(false);
                break;
            case 3:
                _status.text = "Rejected :(";
                _delete.SetActive(true);
                _accept.SetActive(false);
                _ignore.SetActive(false);
                break;
            case 4:
                _status.text = "Ignored XD";
                _delete.SetActive(true);
                _accept.SetActive(false);
                _ignore.SetActive(false);
                break;
            default:
                break;
        }
    }

    public void Delete()
    {
        _dataBase.DeleteFriend(_username, _name.text);
        _action?.Invoke();
    }
    public void Accept()
    {
        _dataBase.UpdateFriend(_username, _name.text,2);
        _action?.Invoke();
    }
    public void Ignore()
    {
        _dataBase.UpdateFriend(_username, _name.text, 3);
        _action?.Invoke();
    }
}
