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
    [SerializeField, Tooltip("Message text.")]
    private TMP_Text _message;

    public void RegisterNewUser()
    {
        _dataBase.Register(_userName.text, _password.text, OnRegisterSucceed, OnRegisterFail);
    }

    public void UserLogIn()
    {
        _dataBase.Login(_userName.text, _password.text, OnLoginSucceed, OnLoginFail);
    }
    private void OnRegisterSucceed(string message)
    {
        _message.text = message;
    }
    private void OnRegisterFail(string message)
    {
        _message.text = message;
    }
    private void OnLoginSucceed(string message)
    {
        _message.text = message;

        _accountScreen.SetActive(true);
        _account.AccountLogged(_userName.text);

        _userName.text = "";
        _password.text = "";

        _myScreen.SetActive(false);
    }

    private void OnLoginFail(string message)
    {
        _message.text = message;

        _password.text = "";
    }

    public void VerifyInputs()
    {
        bool canInteract = (_userName.text.Length >= 4) && (_password.text.Length >= 4);

        _logIn.interactable = _register.interactable = canInteract;
    }
}
