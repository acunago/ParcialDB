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
    [SerializeField, Tooltip("Message text.")]
    private TMP_Text _message;

    private List<GameObject> myRows = new List<GameObject>();
    private string _username = default;

    public void Init(string user)
    {
        _username = user;
    }

    public void Refresh()
    {
        foreach (var item in myRows)
        {
            Destroy(item);
        }

        myRows.Clear();
        _dataBase.GetFriends(_username, OnGetFriendsSucceed, OnGetFriendsFailed);
    }
    private void OnGetFriendsSucceed(string message)
    {
        float yPos = 0;

        string[] rows = message.Split('\n');
        foreach (var item in rows)
        {
            string[] registros = item.Split('\t');
            // 0:Id 1:Solicitante 2:Receptor 3:Status
            if (registros.Length < 2) continue;
            GameObject go = Instantiate(_row, _content.transform);
            myRows.Add(go);
            /* POSIBLE SOLUCION DE POSICION*/
            RectTransform rt = go.GetComponent<RectTransform>();
            rt.anchoredPosition = new Vector2(0, yPos);
            yPos -= 50;

            FriendRow fr = go.GetComponent<FriendRow>();
            int st = int.Parse(registros[3]);
            //0:Null 1:Pendiente 2:Amigos 3:Rechazado
            switch (st)
            {
                case 1: // Invitacion
                    if (registros[1] == _username) // Lo invite yo
                        fr.Init(_dataBase, _username, int.Parse(registros[0]), registros[2], 0, Refresh);
                    else // Me invito el
                        fr.Init(_dataBase, _username, int.Parse(registros[0]), registros[1], 1, Refresh);
                    break;
                case 2: // Amigos
                    if (registros[1] == _username)
                        fr.Init(_dataBase, _username, int.Parse(registros[0]), registros[2], 2, Refresh);
                    else
                        fr.Init(_dataBase, _username, int.Parse(registros[0]), registros[1], 2, Refresh);
                    break;
                case 3: // Rechazo
                    if (registros[1] == _username) // Me rechazo el :(
                        fr.Init(_dataBase, _username, int.Parse(registros[0]), registros[2], 3, Refresh);
                    else // Lo rechace yo XD
                        fr.Init(_dataBase, _username, int.Parse(registros[0]), registros[1], 4, Refresh);
                    break;
                default:
                    break;
            }
        }
    }
    void OnGetFriendsFailed(string message)
    {
        _message.text = message;
    }

    public void Close()
    {
        _myScreen.SetActive(false);
    }
}
