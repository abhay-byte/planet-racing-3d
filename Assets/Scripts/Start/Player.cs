using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Auth;
using System.Security.Cryptography;
using CI.QuickSave;
using SaveSystem;
using Firebase.Firestore;

public class Player : MonoBehaviour
{
    Cryptography cryptography = new Cryptography("Rey@2626");
    private Firebase.Auth.FirebaseAuth auth = null;
    private FirebaseFirestore db;
    string deviceId;

    // Login and sign up variables
    public authGameObjects authData;
    public PlayerGameObjects playerdata;
    public PlayerInvertorySystem InventorySystem;

    public bool curruptedSave;
    public string SavedID;

    public Text State;

    public List<List<string>> Engine;
    public int SelectedEngine;
    public List<List<string>> Chassis;
    public int SelectedChassis;
    public List<string> Material;
    public int SelectedMaterial;
    public List<List<string>> Tires;
    public int SelectedTires;
    public List<List<string>> Nitros;
    public int SelectedNitros;

    public string playerusername;
    public string playerhomeplanet;
    public int playermoney;
    public int playergems;
    public int playerreputation;

    public string currentEngine;
    public string currentChassis;
    public string currentMaterial;
    public string currentTires;
    public string currentNitros;



    void Start()
    {
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        db = FirebaseFirestore.DefaultInstance;
        deviceId = SystemInfo.deviceUniqueIdentifier;
        StartCoroutine(Loading());
        State.text = "";
    }





    IEnumerator Loading()
    {
        yield return new WaitForSeconds(0.1f);

        try
        {
            QuickSaveReader.Create("PlayerData[DonotDeleteThis]")
                .Read<string>(cryptography.Encrypt("ID"), (r) => { SavedID = cryptography.Decrypt<string>(r); })
                .Read<string>(cryptography.Encrypt("Username"), (r) => { playerusername = cryptography.Decrypt<string>(r); })
                .Read<string>(cryptography.Encrypt("Planetname"), (r) => { playerhomeplanet = cryptography.Decrypt<string>(r); })
                .Read<string>(cryptography.Encrypt("Money"), (r) => { playermoney = cryptography.Decrypt<int>(r); })
                .Read<string>(cryptography.Encrypt("Gems"), (r) => { playergems = cryptography.Decrypt<int>(r); })
                .Read<string>(cryptography.Encrypt("Reputation"), (r) => { playerreputation = cryptography.Decrypt<int>(r); })
                .Read<string>(cryptography.Encrypt("Engine"), (r) => { Engine = cryptography.Decrypt<List<List<string>>>(r); })
                .Read<string>(cryptography.Encrypt("Chassis"), (r) => { Chassis = cryptography.Decrypt<List<List<string>>>(r); })
                .Read<string>(cryptography.Encrypt("Material"), (r) => { Material = cryptography.Decrypt<List<string>>(r); })
                .Read<string>(cryptography.Encrypt("Tires"), (r) => { Tires = cryptography.Decrypt<List<List<string>>>(r); })
                .Read<string>(cryptography.Encrypt("Nitros"), (r) => { Nitros = cryptography.Decrypt<List<List<string>>>(r); })

                .Read<string>(cryptography.Encrypt("SelectedEngine"), (r) => { SelectedEngine = cryptography.Decrypt<int>(r); })
                .Read<string>(cryptography.Encrypt("SelectedChassis"), (r) => { SelectedChassis = cryptography.Decrypt<int>(r); })
                .Read<string>(cryptography.Encrypt("SelectedMaterial"), (r) => { SelectedMaterial = cryptography.Decrypt<int>(r); })
                .Read<string>(cryptography.Encrypt("SelectedTires"), (r) => { SelectedTires = cryptography.Decrypt<int>(r); })
                .Read<string>(cryptography.Encrypt("SelectedNitros"), (r) => { SelectedNitros = cryptography.Decrypt<int>(r); });

            if (deviceId != SavedID)
            {
                curruptedSave = true;
            }
            else
            {
                curruptedSave = false;
            }
            updateAuthUI();
            playerdata.homePageUsername.text = playerusername;
            playerdata.homePageHomePlanet.text = playerhomeplanet;
            playerdata.spaceCoins.text = playermoney + "";
            playerdata.spaceGems.text = playergems + "";
            playerdata.Reputation.text = playerreputation + "";
            InventorySystem.InvertoryGenerator();
            State.text = "Touch here to continue.";
        }
        catch (System.Exception Error)
        {
            playerdata.PlayerNamingPanel.SetActive(true);
            Debug.Log(Error);
        }
    }

    public void save()
    {

        QuickSaveWriter.Create("PlayerData[DonotDeleteThis]")
            .Write(cryptography.Encrypt("ID"), cryptography.Encrypt(deviceId))
            .Write(cryptography.Encrypt("Username"), cryptography.Encrypt(playerusername))
            .Write(cryptography.Encrypt("Planetname"), cryptography.Encrypt(playerhomeplanet))
            .Write(cryptography.Encrypt("Money"), cryptography.Encrypt(playermoney))
            .Write(cryptography.Encrypt("Gems"), cryptography.Encrypt(playergems))
            .Write(cryptography.Encrypt("Reputation"), cryptography.Encrypt(playerreputation))
            .Write(cryptography.Encrypt("Engine"), cryptography.Encrypt(Engine))
            .Write(cryptography.Encrypt("Chassis"), cryptography.Encrypt(Chassis))
            .Write(cryptography.Encrypt("Material"), cryptography.Encrypt(Material))
            .Write(cryptography.Encrypt("Tires"), cryptography.Encrypt(Tires))
            .Write(cryptography.Encrypt("Nitros"), cryptography.Encrypt(Nitros))

            .Write(cryptography.Encrypt("SelectedEngine"), cryptography.Encrypt(SelectedEngine))
            .Write(cryptography.Encrypt("SelectedChassis"), cryptography.Encrypt(SelectedChassis))
            .Write(cryptography.Encrypt("SelectedMaterial"), cryptography.Encrypt(SelectedMaterial))
            .Write(cryptography.Encrypt("SelectedTires"), cryptography.Encrypt(SelectedTires))
            .Write(cryptography.Encrypt("SelectedNitros"), cryptography.Encrypt(SelectedNitros))
            .Commit();
    }

    public void firstDataSave()
    {
        if (playerdata.name.text != "" && playerdata.homePlanet.text != "")
        {
            List<string> engine = new List<string>(new string[] { "40 HP Basic", "100" });
            Engine = new List<List<string>> { engine };

            List<string> chassis = new List<string>(new string[] { "Micro", "400" });
            Chassis = new List<List<string>> { chassis };

            List<string> Material = new List<string>(new string[] { "Iron" });

            List<string> tires = new List<string>(new string[] { "Low Grip", "120" });
            Tires = new List<List<string>> { tires };

            List<string> nitros = new List<string>(new string[] { "1 Litre", "100" });
            Nitros = new List<List<string>> { nitros };


            QuickSaveWriter.Create("PlayerData[DonotDeleteThis]")
                .Write(cryptography.Encrypt("ID"), cryptography.Encrypt(deviceId))
                .Write(cryptography.Encrypt("Username"), cryptography.Encrypt(playerdata.name.text))
                .Write(cryptography.Encrypt("Planetname"), cryptography.Encrypt(playerdata.homePlanet.text))
                .Write(cryptography.Encrypt("Money"), cryptography.Encrypt(5000))
                .Write(cryptography.Encrypt("Gems"), cryptography.Encrypt(100))
                .Write(cryptography.Encrypt("Reputation"), cryptography.Encrypt(1))
                .Write(cryptography.Encrypt("Engine"), cryptography.Encrypt(Engine))
                .Write(cryptography.Encrypt("Chassis"), cryptography.Encrypt(Chassis))
                .Write(cryptography.Encrypt("Material"), cryptography.Encrypt(Material))
                .Write(cryptography.Encrypt("Tires"), cryptography.Encrypt(Tires))
                .Write(cryptography.Encrypt("Nitros"), cryptography.Encrypt(Nitros))

                .Write(cryptography.Encrypt("SelectedEngine"), cryptography.Encrypt(0))
                .Write(cryptography.Encrypt("SelectedChassis"), cryptography.Encrypt(0))
                .Write(cryptography.Encrypt("SelectedMaterial"), cryptography.Encrypt(0))
                .Write(cryptography.Encrypt("SelectedTires"), cryptography.Encrypt(0))
                .Write(cryptography.Encrypt("SelectedNitros"), cryptography.Encrypt(0))
                .Commit();
            State.text = "Touch here to continue.";
            playerdata.PlayerNamingPanel.SetActive(false);
            playerdata.homePageUsername.text = playerusername;
            playerdata.homePageHomePlanet.text = playerhomeplanet;
            playerdata.spaceCoins.text = playermoney + "";
            playerdata.spaceGems.text = playergems + "";
            playerdata.Reputation.text = playerreputation + "";
            InventorySystem.InvertoryGenerator();
            updateAuthUI();

        }
    }
    private void updateAuthUI()
    {
        {
            auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
            Debug.Log("Inside Update UI");
            if (auth?.CurrentUser != null)
            {
                string CurrentUserID = auth.CurrentUser.UserId;
                authData.SettingsSignupButton.SetActive(false);
                authData.SettingsLogoutButton.SetActive(true);


            }
            else
            {
                authData.SettingsSignupButton.SetActive(true);
                authData.SettingsLogoutButton.SetActive(false);
            }
        };

    }
    void Update()
    {

    }

    public async void Login()
    {
        try
        {

            var firebaseUser = await auth.SignInWithEmailAndPasswordAsync(authData.email.text, authData.password.text);
            updateAuthUI();
            Debug.LogFormat("User signed in successfully: {0} ({1})",
                firebaseUser.DisplayName, firebaseUser.UserId);
            authData.Auth.SetActive(false);

        }
        catch (System.Exception e)
        {
            Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
            Debug.Log(e.Data);
            authData.warningMessage.text = "Error";

        }


    }

    public async void Signup()
    {
        UserProfile profile = new UserProfile { DisplayName = playerusername };
        try
        {
            if (authData.password.text == authData.confirmPassword.text)
            {
                var firebaseUser = await auth
                    .CreateUserWithEmailAndPasswordAsync(password: authData.password.text, email: authData.email.text);

                if (firebaseUser == null)
                {
                    Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
                    return;
                }
                updateAuthUI();
                Debug.LogFormat("User signed in successfully: {0} ({1})",
                    firebaseUser.DisplayName, firebaseUser.UserId);
                authData.Auth.SetActive(false);

                await firebaseUser.UpdateUserProfileAsync(profile: profile);
                Debug.Log("Successfull name change");

                await firebaseUser.SendEmailVerificationAsync();
                Debug.Log("Send email verification");
            }
        }
        catch (System.Exception e)
        {
            Debug.Log("UpdateUserProfileAsync encountered an error" + e.Data);

        }

    }
    public void LoginTransition()
    {
        authData.Head.text = "Login";
        authData.Body.text = "Login to your account to continue your progress.";
        authData.ConfirmPassword.SetActive(false);
        authData.Username.SetActive(false);

        authData.LoginTransition.SetActive(false);
        authData.SignupAuth.SetActive(false);

        authData.SignupTransition.SetActive(true);
        authData.LoginAuth.SetActive(true);

    }

    public void SignUpTransition()
    {
        authData.Auth.SetActive(true);
        authData.Head.text = "Signup";
        authData.Body.text = "Create an account to save your progress on cloud.";
        authData.ConfirmPassword.SetActive(true);
        authData.Username.SetActive(false);

        authData.LoginTransition.SetActive(true);
        authData.SignupAuth.SetActive(true);

        authData.SignupTransition.SetActive(false);
        authData.LoginAuth.SetActive(false);
    }
    public void logout()
    {
        auth?.SignOut();
        updateAuthUI();
    }

    private void OnDestroy()
    {
        Debug.Log("Inside Destroyed!");
        // auth.StateChanged -= (a, b) => { };
        // auth = null;
    }
}
