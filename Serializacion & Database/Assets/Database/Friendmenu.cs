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

    }

    public void Close()
    {
        _myScreen.SetActive(false);
    }
}
