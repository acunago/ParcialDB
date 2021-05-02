using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [Header("UI Settings")]
    [SerializeField, Tooltip("My screen.")]
    private GameObject _myScreen;
    [SerializeField, Tooltip("Log-In screen.")]
    private GameObject _loginScreen;

    public void Enter()
    {
        _loginScreen.SetActive(true);
        _myScreen.SetActive(false);
    }
}
