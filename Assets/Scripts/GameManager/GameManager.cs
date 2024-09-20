using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int HighScore
    {
        get
        {
            return PlayerPrefs.GetInt(Constants.DATA.HIGH_SCORE, 0);
        }
        set
        {
            PlayerPrefs.SetInt(Constants.DATA.HIGH_SCORE, value);
        }
    }

    public int CurrentScore
    { get; set; }

    public bool IsInitialized
    { get; set; }

    [Header("SFX && VFX")]
    public GameObject winParticleEffect;
    public GameObject lossParticleEffect;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            Init();
            return;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Init()
    {

    }

}

public enum ShapeType
{
    Circle,
    Square,
    Triangle,
    Undefined
}
