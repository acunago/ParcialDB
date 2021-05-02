using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

    public void Init(DBAdmin db, string user, string name, int status)
    {
        _dataBase = db;
        _username = user;

        _name.text = name;

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
                _status.text = "rejected";
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
        //CODIGO GONZA
    }
    public void Accept()
    {
        //CODIGO GONZA
    }
    public void Ignore()
    {
        //CODIGO GONZA
    }
}
