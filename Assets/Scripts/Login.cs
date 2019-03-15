using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace sql
{

    public class Login : MonoBehaviour
    {
        [Header("Create User Fields")]
        public InputField create_username;
        public InputField email, password, reEnterPassword;

        [Header("Log In Fields")]
        public InputField login_username;
        public InputField login_password;


        public Text notification;

        // Update is called once per frame
        void Update()
        {
            if (notification.text != "" && !notification.enabled)
            {
                notification.enabled = true;
            }
            if (notification.text == "" && notification.enabled)
            {
                notification.enabled = false;
            }
        }

        public void CreateUserButton()
        {
            if (password.text == reEnterPassword.text)
            {
                notification.text = "";
                StartCoroutine(CreateUser(create_username.text, email.text, password.text));
            }
            else
            {
                Debug.Log("Password not same!");
            }
        }

        IEnumerator CreateUser(string _username, string _email, string _password)
        {
            // PHP link
            string createUserURL = "http://localhost/squealsystem/InsertUser.php";

            // Info to send to the POST variable in PHP
            WWWForm insertUserForm = new WWWForm();
            insertUserForm.AddField("usernamePost", _username);
            insertUserForm.AddField("emailPost", _email);
            insertUserForm.AddField("passwordPost", _password);

            WWW www = new WWW(createUserURL, insertUserForm);

            yield return www;
            if (www.text == "User Already ExistsEmail already exists")
            {
                notification.text = "Account Exists";
            }
            else
            {
                notification.text = www.text;
            }
            Debug.Log(www.text);
        }
    }
}
