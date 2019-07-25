using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

public class PlayFabLogin : MonoBehaviour
{

    private string userEmail;
    private string userPassword;
    private string userName;
    public GameObject LoginPanel;
    public GameObject Timer;
    public GameObject Cube;

    public void GetUserEmail(string emailIn)
    {

        userEmail = emailIn;

    }

    public void GetUserPassword(string passwordIn)
    {

        userPassword = passwordIn;

    }

    public void GetUserName(string usernameIn)
    {

        userName = usernameIn;

    }

    public void OnClickLogIn()
    {

        var request = new LoginWithEmailAddressRequest
        {

            Email = userEmail,
            Password = userPassword

        };

        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnLoginFailure);

    }

    public void Start()
    {

        Cube.SetActive(false);
        Timer.SetActive(false);

        //Note: Setting title Id here can be skipped if you have set the value in Editor Extensions already.
        if (string.IsNullOrEmpty(PlayFabSettings.TitleId))
        {
            PlayFabSettings.TitleId = "F8E62"; // Please change this value to your own titleId from PlayFab Game Manager
        }
        //var request = new LoginWithCustomIDRequest { CustomId = "GettingStartedGuide", CreateAccount = true };
        //PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnLoginFailure);

        if (PlayerPrefs.HasKey("EMAIL"))
        {

            userEmail = PlayerPrefs.GetString("EMAIL");
            userPassword = PlayerPrefs.GetString("PASSWORD");

            var request = new LoginWithEmailAddressRequest
            {

                Email = userEmail,
                Password = userPassword

            };

            PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnLoginFailure);
        }

        
    }

    private void OnLoginSuccess(LoginResult result)
    {
        Debug.Log("Login Succesfull!");
        PlayerPrefs.SetString("EMAIL", userEmail);
        PlayerPrefs.SetString("PASSWORD", userPassword);
        LoginPanel.SetActive(false);
        Cube.SetActive(true);
        Timer.SetActive(true);
    }

    private void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {

        Debug.Log("Registering Succesfull!");
        PlayerPrefs.SetString("EMAIL", userEmail);
        PlayerPrefs.SetString("PASSWORD", userPassword);
        LoginPanel.SetActive(false);
        Cube.SetActive(true);
        Timer.SetActive(true);

    }

    private void OnLoginFailure(PlayFabError error)
    {

        var registerRequest = new RegisterPlayFabUserRequest
        {

            Email = userEmail,
            Password = userPassword,
            Username = userName

        };

        PlayFabClientAPI.RegisterPlayFabUser(registerRequest, OnRegisterSuccess, OnRegisterFailure);

    }

    private void OnRegisterFailure(PlayFabError error)
    {

        Debug.LogError(error.GenerateErrorReport());

    }

}