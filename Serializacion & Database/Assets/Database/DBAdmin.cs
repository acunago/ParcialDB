using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class DBAdmin : MonoBehaviour
{
    [Header("Data Base Setting")]
    [SerializeField, Tooltip("Mamp server name.")]
    private string _host;
    [SerializeField, Tooltip("Data base name.")]
    private string _database;
    [SerializeField, Tooltip("User name.")]
    public string _userName;
    [SerializeField, Tooltip("Required password.")]
    public string _password;

    private IEnumerator DoQuery(string phpScript, WWWForm form, Action<string> successCallback = null, Action<string> failureCallback = null)
    {
        UnityWebRequest www = UnityWebRequest.Post("http://localhost/" + phpScript + ".php", form);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            if (www.downloadHandler.text[0] == '0')
            {
                Debug.Log("Ok");
                successCallback?.Invoke(www.downloadHandler.text);
            }
            else
            {
                Debug.Log("Fail");
                failureCallback?.Invoke(www.downloadHandler.text);
            }
        }
    }

    private WWWForm CreateForm()
    {
        WWWForm form = new WWWForm();
        form.AddField("host", _host);
        form.AddField("database", _database);
        form.AddField("dbuser", _userName);
        form.AddField("dbpw", _password);

        return form;
    }

    public void Register(string username, string password)
    {
        WWWForm form = CreateForm();
        form.AddField("user", username);
        form.AddField("pass", password);

        StartCoroutine(DoQuery("register", form));
    }

    public void Login(string username, string password, Action<string> successCallback, Action<string> failureCallback)
    {
        WWWForm form = CreateForm();

        string query = "SELECT usern FROM `accounts` WHERE usern = ('" + username + "') AND passw = ('" + password + "');";
        form.AddField("query", query);

        StartCoroutine(DoQuery("login", form, successCallback, failureCallback));
    }

    public void SetScore(string username, string score)
    {
        WWWForm form = CreateForm();
        form.AddField("user", username);
        form.AddField("score", score);

        StartCoroutine(DoQuery("setscore", form));
    }

    public void GetScore(string username, Action<string> successCallback, Action<string> failureCallback)
    {
        WWWForm form = CreateForm();

        string query = "SELECT score FROM `highscores` WHERE user = ('" + username + "');";
        form.AddField("query", query);

        StartCoroutine(DoQuery("getscore", form, successCallback, failureCallback));
    }

    public void DeleteScore(string username, Action<string> successCallback)
    {
        WWWForm form = CreateForm();

        form.AddField("user", username);

        StartCoroutine(DoQuery("deletescore", form, successCallback));
    }

    public void FriendRequest(string username, string friendname)
    {
        //WWWForm form = CreateForm();

        //form.AddField("user", username);
        //form.AddField("score", friendname);

        //StartCoroutine(DoQuery("setscore", form));
    }

    public void GetFriends(string username, Action<string> successCallback, Action<string> failureCallback)
    {
        //WWWForm form = CreateForm();

        //string query = "SELECT score FROM `highscores` WHERE user = ('" + username + "');";
        //form.AddField("query", query);

        //StartCoroutine(DoQuery("getscore", form, successCallback, failureCallback));
    }

    public void DeleteFriend(string username, Action<string> successCallback)
    {
        //WWWForm form = CreateForm();

        //form.AddField("user", username);

        //StartCoroutine(DoQuery("deletescore", form, successCallback));
    }
}
