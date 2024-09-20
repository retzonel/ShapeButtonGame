using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameplayManager : MonoBehaviour
{
    [Header("Spawning Shapes")]
    [SerializeField] Transform spawnPoint;
    public Transform goalTransform;
    [SerializeField] private float timeBetweenShapes = 2f;
    public float countdown;

    [Space]
    public ShapeType goalCurrentType;
    [SerializeField] private ShapesSO[] shapesArray;

    [Space]
    [SerializeField] private GameObject[] shapeBtns;
    [SerializeField] private RectTransform btnsContainer;

    public static GameplayManager instance;

    [Header("Goal Vars")]
    [SerializeField] private SpriteRenderer goalSprite;
    [SerializeField] private Sprite defaultCaseGoalSprite;

    [Header("Gameplay Variables")]
    public int startHealth = 5;
    [SerializeField] private int health;
    public int level;
    [SerializeField] private int score;
    public bool hasGameFinished {get; private set;}
    public UnityEvent GameEnd;

    [Header("Gameplay UI")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthText;

    void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    void Start()
    {
        CreateUIButtons();
        Init();
        hasGameFinished = false;
        goalSprite.sprite = defaultCaseGoalSprite;
        goalCurrentType = ShapeType.Undefined;
    }

    void Init()
    {
        health = startHealth;
    }

    void Update()
    {
        if(health <= 0)
        {
            GameEnded();
        }

        scoreText.text = score.ToString();

        if (hasGameFinished) return;
        healthText.text = health.ToString();

        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        SpawnShapes();
    }

    void CreateUIButtons()
    {
        foreach (GameObject shapeBtn in shapeBtns)
        {
            GameObject go = Instantiate(shapeBtn, btnsContainer) as GameObject;
            ShapesSO myData = go.GetComponent<ShapeButton>().myData;
            go.GetComponent<ShapeButton>().InitButton();
            go.GetComponent<Button>().onClick.AddListener(() =>
            {
                goalCurrentType = myData.shapeType;
                goalSprite.sprite = myData.shapeSprite;
            });
        }
    }

    void SpawnShapes()
    {
        if (countdown <= 0f)
        {
            GameObject go = shapesArray[Random.Range(0, shapesArray.Length)].shapePrefab;
            Instantiate(go, spawnPoint);
            countdown = timeBetweenShapes;
            return;
        }
    }

    public void DecreaseHealth()
    {
        health--;
    }

    public void IncrementScore()
    {
        score++;
    }

    void GameEnded()
    {
        GameEnd.Invoke();

        int currentScore = GameManager.instance.CurrentScore;
        int highScore = GameManager.instance.HighScore;

        if(highScore < currentScore)
        {
            GameManager.instance.HighScore = currentScore;
        }

        GameManager.instance.CurrentScore = score;
        hasGameFinished = true;
    }
}
