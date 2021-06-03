using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Login_UIHandler : MonoBehaviour
{
    public static string LoginUsername;

    private static Text LoginMSG;
    private static Text LoginStatus;
    private static InputField UsernameField;
    private static InputField PasswordField;
    private static Button LoginBtn;

    private static Image ImageOnline;
    private static Image ImageMaintainance;
    private static Image ImageOffline;

    public static Login_UIHandler instance;

    private void Start()
    {
        LoginMSG = GameObject.Find("Text_ServerWelcome").GetComponent<Text>();
        ImageOnline = GameObject.Find("Image_Status_Online").GetComponent<Image>();
        ImageMaintainance = GameObject.Find("Image_Status_Maintainance").GetComponent<Image>();
        ImageOffline = GameObject.Find("Image_Status_Offline").GetComponent<Image>();
        UsernameField = GameObject.Find("Input_Username").GetComponent<InputField>();
        PasswordField = GameObject.Find("Input_Password").GetComponent<InputField>();
        LoginBtn = GameObject.Find("Button_Login").GetComponent<Button>();
        LoginStatus = GameObject.Find("Text_LoginStatus").GetComponent<Text>();

        ImageOnline.enabled = false;
        ImageMaintainance.enabled = false;
        ImageOffline.enabled = true;
        LoginStatus.enabled = false;
        LoginBtn.onClick.AddListener(LoginBtn_Click);
        instance = this;
    }


    public void LoginBtn_Click()
    {
        LoginUsername = UsernameField.text;
        Client.instance.username = LoginUsername;
        string _username = UsernameField.text;
        if (_username.Length == 0 || _username == "Enter your Username")
        {
            LoginStatus.color = new Color(255, 0, 0, 255);
            LoginStatus.text = "Username Field is empty";
            LoginStatus.enabled = true;
        }
        else
        {
            LoginStatus.color = new Color(255, 255, 255, 255);
            //LoginStatus.text = "Connecting to the server..";
            LoginStatus.enabled = true;
            ClientSend.LoginAttempt();
        }
    }

    //Actualizamos el mensaje de bienvenida al juego con la información recibida del paquete.
    public static void Login_Mensaje(string _text)
    {
        LoginMSG.text = _text;
    }

    //Actualizamos la imágen con el estado del servidor tras recibir el paquete.
    public static void Login_ActualizarEstado()
    {
        if(Globals.ServerStatus == 1)
        {
            ImageOnline.enabled = true;
            ImageMaintainance.enabled = false;
            ImageOffline.enabled = false;
        }
        if (Globals.ServerStatus == 2)
        {
            ImageOnline.enabled = false;
            ImageMaintainance.enabled = true;
            ImageOffline.enabled = false;
        }
        if (Globals.ServerStatus == 3)
        {
            ImageOnline.enabled = false;
            ImageMaintainance.enabled = false;
            ImageOffline.enabled = true;
        }
    }

    private IEnumerator LogIn()
    {
        LoginStatus.text = "Now you are logged in";
        yield return new WaitForSeconds(3f);
        LoginStatus.text = "Sending to the lobby..";
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Home");
    }
}

