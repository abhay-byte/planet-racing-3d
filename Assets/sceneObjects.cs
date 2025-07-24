using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sceneObjects : MonoBehaviour
{
    public Transform twoPlayer;
    public GameObject TrackNo1;
    public Transform aiPlayer;
    public Transform checkpointListT1;

    public GameObject WrongDirectionM1;
    public GameObject WrongDirectionM2;
    public GameObject WrongDirectionUniversal;
    public CanvasGroup HomeUI;
    public CanvasGroup RaceUI;
    public Slider PlayerSlider1;
    public Slider PlayerSlider2;
    public Slider PlayerSliderUniversal;

    public Text MlapsPlayer1;
    public Text MlapsPlayer2;

    public Rigidbody PlayerM1Rigidbody;
    public Rigidbody PlayerM2Rigidbody;

    public List<GameObject> WrongDirectionPlayer;

    private List<Vector3> MT1PlayerPosition = new List<Vector3>()
    {new Vector3(-1789.088f, 761f, -1461.608f),new Vector3(-1789.088f, 760.5f, -1461.608f)};
    public List<float> MT1PlayerRotation = new List<float>()
    {0,-90f,0};
    // public List<Rigidbody> playerRigidbody = new List<Rigidbody>()
    // {PlayerM1Rigidbody,PlayerM2Rigidbody};
    private Vector3 MT1Player1Position = new Vector3(-1789.088f, 761f, -1461.608f);
    private Vector3 MT1Player2Position = new Vector3(-1789.088f, 760.5f, -1461.608f);

    public Vector3 MT1Player1Position1 { get => MT1Player1Position; set => MT1Player1Position = value; }
    public Vector3 MT1Player2Position1 { get => MT1Player2Position; set => MT1Player2Position = value; }
    public List<Vector3> MT1PlayerPosition1 { get => MT1PlayerPosition; set => MT1PlayerPosition = value; }

    void Start()
    {

        WrongDirectionPlayer = new List<GameObject>()
        {
            WrongDirectionM1,WrongDirectionM2
        };
    }
}
