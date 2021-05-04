using TMPro;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [Header("UI Settings")]
    [SerializeField, Tooltip("My screen.")]
    private GameObject _myScreen;
    [SerializeField, Tooltip("Log-In screen.")]
    private GameObject _loginScreen;
    [SerializeField, Tooltip("Message text.")]
    private TMP_Text _message;

    private void OnEnable()
    {
        _message.text = "You are not logged.";
    }

    public void Enter()
    {
        _loginScreen.SetActive(true);
        _myScreen.SetActive(false);
    }
}
