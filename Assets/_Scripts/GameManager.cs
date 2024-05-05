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
    private float gameSoundVolume;
    private float musicSoundVolume;

    private void Awake()
    {
        Instance = this;
        // TODO - make sure these work and change this to retreiving the save data
        gameSoundVolume = 5f;
        musicSoundVolume = 5f;
    }

    private void Start()
    {
    }

    public string GetPlayerName()
    {
        return playerName;
    }

    public float GetGameSoundVolume()
    {
        return gameSoundVolume;
    }

    public float GetMusicSoundVolume()
    {
        return musicSoundVolume;
    }
}