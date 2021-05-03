using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Friendmenu : MonoBehaviour
{
    [SerializeField, Tooltip("Data base intance.")]
    private DBAdmin _dataBase;
    [SerializeField, Tooltip("Friend row prefab.")]
    private GameObject _row;

    [Header("UI Settings")]
    [SerializeField, Tooltip("My screen.")]
    private GameObject _myScreen;
    [SerializeField, Tooltip("Scrollview content.")]
    private GameObject _content;

    private string _username;

    public void Init(string user)
    {
        _username = user;
    }

    public void Refresh()
    {
        _dataBase.GetFriends(_username, OnGetFriendsSucceed);
    }
    private void OnGetFriendsSucceed(string message)
    {

        FriendRow friendRow;

        string[] rows = message.Split('\n');
        foreach (var item in rows)
        {
            string[] registros = item.Split('\t');
            for (int i = 1; i < registros.Length; i++)
            {
                GameObject go = Instantiate(_row);
                go.transform.SetParent(_content.transform);
                if (go.TryGetComponent<FriendRow>(out friendRow)){

                    friendRow.Init(_dataBase, _username, registros[2], int.Parse(registros[3]), int.Parse(registros[0]));
                }
            }
        }

        Debug.Log(message);
    }

    public void Close()
    {
        _myScreen.SetActive(false);
    }
}
