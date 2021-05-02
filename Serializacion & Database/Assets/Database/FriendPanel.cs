﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FriendPanel : MonoBehaviour
{
    [SerializeField, Tooltip("Friend Instance.")]
    private Friendmenu _friends;

    [Header("UI Settings")]
    [SerializeField, Tooltip("Frien list screen.")]
    private GameObject _friendScreen;
    [SerializeField, Tooltip("Friend name input field.")]
    private TMP_InputField _friendName;

    private DBAdmin _dataBase;
    private string _username;

    public void Init(DBAdmin db, string user)
    {
        _dataBase = db;
        _username = user;
    }
    public void OnClose()
    {
        _friendScreen.SetActive(false);
    }

    public void SendIvitation()
    {
        //CODIGO DE GONZA

        _friends.Refresh();
    }

    public void DeleteFriend()
    {
        //CODIGO DE GONZA

        _friends.Refresh();
    }

    public void ShowFriendList()
    {
        _friendScreen.SetActive(true);
        _friends.Init(_username);
        _friends.Refresh();
    }
}
