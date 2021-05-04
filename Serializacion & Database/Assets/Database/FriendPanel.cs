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

    private DBAdmin _dataBase = default;
    private string _username = default;
    private TMP_Text _message = default;

    public void Init(DBAdmin db, string user, TMP_Text message)
    {
        _dataBase = db;
        _username = user;
        _message = message;
    }
    public void OnClose()
    {
        _friendName.text = "";
        _friendScreen.SetActive(false);
    }

    public void SendIvitation()
    {
        _dataBase.FriendRequest(_username, _friendName.text, SendIvitationSucceed, SendIvitationFailed);


    }
    void SendIvitationSucceed(string message)
    {
        _message.text = "";
        ShowFriendList();
    }
    void SendIvitationFailed(string message)
    {
        _message.text = message;
    }

    public void DeleteFriend()
    {
        _dataBase.DeleteFriend(_username, _friendName.text, DeleteFriendSucceed, DeleteFriendFailed);

        ShowFriendList();
    }
    void DeleteFriendSucceed(string message)
    {
        _message.text = message;
    }
    void DeleteFriendFailed(string message)
    {
        _message.text = message;
    }

    public void ShowFriendList()
    {
        _friendScreen.SetActive(false); //refresh debido al scroll view
        _friendScreen.SetActive(true);
        _friends.Init(_username, ShowFriendList);
        _friends.Refresh();
    }

}
