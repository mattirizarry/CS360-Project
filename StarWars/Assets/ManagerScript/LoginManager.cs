using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Firebase;
using Firebase.Auth;
using UnityEngine.SceneManagement;

public class LoginManager : MonoBehaviour
{

    [Header("Firebase")]
    public DependencyStatus dependencyStatus;
    public FirebaseAuth auth;
    public FirebaseUser User;

    [Header("Login UI")]
    public TMP_InputField emailField;
    public TMP_InputField passwordField;
    public TMP_Text warningText;
    public TMP_Text confirmLoginText;

    [Header("Register UI")]
    public TMP_InputField registerEmailField;
    public TMP_InputField registerPasswordField;
    public TMP_Text registerWarningText;

    // Declare next scene
    public string nextScene;

    private void Awake() {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
            dependencyStatus = task.Result;
            if (dependencyStatus == DependencyStatus.Available) {
                InitializeFirebase();
            } else {
                Debug.LogError("Could not resolve all Firebase dependencies: " + dependencyStatus);
            }
        });
    }

    private void InitializeFirebase() {
        Debug.Log("Setting up Firebase Auth");
        auth = FirebaseAuth.DefaultInstance;
    }

    public void LoginButton() {
        Debug.Log("Login Button Pressed");
        StartCoroutine(Login(emailField.text, passwordField.text));
    }

    public void RegisterButton() {
        StartCoroutine(Register(registerEmailField.text, registerPasswordField.text, registerPasswordField.text));
    }

    private IEnumerator Login(string _email, string _password) {
        var LoginTask = auth.SignInWithEmailAndPasswordAsync(_email, _password);
        yield return new WaitUntil(predicate: () => LoginTask.IsCompleted);

        if (LoginTask.Exception != null) {
            Debug.LogWarning(message: $"Failed to register task with {LoginTask.Exception}");
            FirebaseException firebaseEx = LoginTask.Exception.GetBaseException() as FirebaseException;
            AuthError errorCode = (AuthError)firebaseEx.ErrorCode;

            string message = "Login Failed!";
            switch (errorCode) {
                case AuthError.MissingEmail:
                    message = "Missing Email";
                    break;
                case AuthError.MissingPassword:
                    message = "Missing Password";
                    break;
                case AuthError.WrongPassword:
                    message = "Wrong Password";
                    break;
                case AuthError.InvalidEmail:
                    message = "Invalid Email";
                    break;
                case AuthError.UserNotFound:
                    message = "Account does not exist";
                    break;
            }
            warningText.text = message;
        } else {
            User = LoginTask.Result.User;
            Debug.LogFormat("User signed in successfully: {0} ({1})", User.DisplayName, User.Email);
            warningText.text = "";
            confirmLoginText.text = "Logged in as " + " (" + User.Email + ")";

        // redirect to the game scene  

            yield return new WaitForSeconds(1.5f);

            SceneManager.LoadScene("MainMenu");
        }
    }

    private IEnumerator Register(string _email, string _password, string _confirmPassword) {
        if (_email == "") {
            registerWarningText.text = "Missing Email";
        } else if (_password != _confirmPassword) {
            registerWarningText.text = "Passwords do not match";
        } else {
            var RegisterTask = auth.CreateUserWithEmailAndPasswordAsync(_email, _password);
            yield return new WaitUntil(predicate: () => RegisterTask.IsCompleted);

            if (RegisterTask.Exception != null) {
                Debug.LogWarning(message: $"Failed to register task with {RegisterTask.Exception}");
                FirebaseException firebaseEx = RegisterTask.Exception.GetBaseException() as FirebaseException;
                AuthError errorCode = (AuthError)firebaseEx.ErrorCode;

                string message = "Register Failed!";
                switch (errorCode) {
                    case AuthError.MissingEmail:
                        message = "Missing Email";
                        break;
                    case AuthError.MissingPassword:
                        message = "Missing Password";
                        break;
                    case AuthError.WeakPassword:
                        message = "Weak Password";
                        break;
                    case AuthError.EmailAlreadyInUse:
                        message = "Email already in use";
                        break;
                }
                registerWarningText.text = message;
            } else {
                User = RegisterTask.Result.User;
                if (User != null) {
                    UserProfile profile = new UserProfile { DisplayName = _email };
                    var ProfileTask = User.UpdateUserProfileAsync(profile);
                    yield return new WaitUntil(predicate: () => ProfileTask.IsCompleted);

                    if (ProfileTask.Exception != null) {
                        Debug.LogWarning(message: $"Failed to register task with {ProfileTask.Exception}");
                        FirebaseException firebaseEx = ProfileTask.Exception.GetBaseException() as FirebaseException;
                        AuthError errorCode = (AuthError)firebaseEx.ErrorCode;
                        registerWarningText.text = "Username Set Failed!";
                    } else {
                        Debug.LogFormat("Username set successfully.");
                        registerWarningText.text = "";
                    }

                Login(registerEmailField.text, registerPasswordField.text);
                }
            }
        } 
    }

    public void ExitToDesktop() {
        Application.Quit();
    }
}
