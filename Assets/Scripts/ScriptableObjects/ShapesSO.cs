using System;
using UnityEngine;

[CreateAssetMenu(fileName = "NewShape", menuName = "CreateShape", order = 0)]
public class ShapesSO : ScriptableObject {
    public string shapeName;
    public Sprite shapeSprite;
    public ShapeType shapeType;
    public GameObject shapePrefab;
    public AudioClip winSound;
    public AudioClip loseSound;
}
