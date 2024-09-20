using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShapeButton : MonoBehaviour
{
    public ShapesSO myData;

    public void InitButton()
    {
        gameObject.name = myData.shapeName+ "Button";
    }
}
