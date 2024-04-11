using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEditor;
using UnityEditor.UI;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private string playerName;

    private void Awake()
    {
        Instance = this;
    }

    public string GetPlayerName()
    {
        return playerName;
    }
}