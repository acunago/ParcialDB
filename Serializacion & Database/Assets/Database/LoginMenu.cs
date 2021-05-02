using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoginMenu : MonoBehaviour
{
    [SerializeField, Tooltip("Data base intance.")]
    private DBAdmin _dataBase;
    [SerializeField, Tooltip("Account intance.")]
    private AccountMenu _account;

    [Header("UI Settings")]
    [SerializeField, Tooltip("My screen.")]
    private GameObject _myScreen;
    [SerializeField, Tooltip("Account screen.")]
    private GameObject _accountScreen;
    [SerializeField, Tooltip("User name input field.")]
    private TMP_InputField _userName;
    [SerializeField, Tooltip("Password input field.")]
    private TMP_InputField _password;
    [SerializeField, Tooltip("Log-in button.")]
    private Button _logIn;
    [SerializeField, Tooltip("Register button.")]
    private Button _register;

    public void RegisterNewUser()
    {
        _dataBase.Register(_userName.text, _password.text);
    }

    public void UserLogIn()
    {
        _dataBase.Login(_userName.text, _password.text, OnLoginSucceed, OnLoginFail);
    }

    private void OnLoginSucceed(string message)
    {
        Debug.Log(message);
        _accountScreen.SetActive(true);
        _account.AccountLogged(_userName.text);

        _userName.text = "";
        _password.text = "";

        _myScreen.SetActive(false);
    }

    private void OnLoginFail(string message)
    {
        Debug.Log(message);

        _password.text = "";
    }

    public void VerifyInputs()
    {
        bool canInteract = (_userName.text.Length >= 4) && (_password.text.Length >= 4);

        _logIn.interactable = _register.interactable = canInteract;
    }
}
