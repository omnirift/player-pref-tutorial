using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

/* Copyright (C) Bilal Itani - All Rights Reserved
 * Unauthorized copying of this file, via any medium is strictly prohibited
 * Proprietary and confidential
 * Written by Bilal Itani <bilalitani1@gmail.com>, March 2016
 */
public enum Difficulty { Fast, Faster, Fastest }

public class SettingsManager : MonoBehaviour
{
    #region Settings Component References

    public Slider volumeSliderSound;

    public Slider volumeSliderMusic;

    public Slider volumeSliderVoice;

    public Toggle enableTips;

    public Toggle enableBloom;

    public Toggle fastDifficulty;

    public Toggle fasterDifficulty;

    public Toggle fastestDifficulty;

    #endregion

    #region Player Pref Key Constants

    private const string MUSIC_VOLUME_PREF = "music-volume";
    private const string SFX_VOLUME_PREF = "sound-volume";
    private const string VO_VOLUME_PREF = "voice-volume";

    private const string DIFFICULTY_PREF = "difficulty";

    private const string TIPS_PREF = "tips";

    private const string BLOOM_PREF = "bloom";

    #endregion

    private Difficulty currentDifficulty = Difficulty.Fast;
    
    void Start()
    {
        int difficulty = PlayerPrefs.GetInt(DIFFICULTY_PREF, (int) Difficulty.Fast);
        currentDifficulty = (Difficulty)difficulty;

        bool isFast = difficulty == (int)Difficulty.Fast;
        bool isFaster = difficulty == (int)Difficulty.Faster;
        bool isFastest = difficulty == (int)Difficulty.Fastest;

        fastDifficulty.isOn = isFast;
        fasterDifficulty.isOn = isFaster;
        fastestDifficulty.isOn = isFastest;

        volumeSliderMusic.value = PlayerPrefs.GetFloat(MUSIC_VOLUME_PREF, 1);
        volumeSliderSound.value = PlayerPrefs.GetFloat(SFX_VOLUME_PREF, 1);
        volumeSliderVoice.value = PlayerPrefs.GetFloat(VO_VOLUME_PREF, 1);

        enableTips.isOn = GetBoolPref(TIPS_PREF);

        enableBloom.isOn = GetBoolPref(BLOOM_PREF);
    }

    #region Difficulty

    public void OnToggleFastDifficulty(bool state)
    {
        if (state)
        {
            SetDifficulty(Difficulty.Fast);
        }
    }

    public void OnToggleFasterDifficulty(bool state)
    {
        if (state)
        {
            SetDifficulty(Difficulty.Faster);
        }
    }

    public void OnToggleFastestDifficulty(bool state)
    {
        if (state)
        {
            SetDifficulty(Difficulty.Fastest);
        }
    }

    private void SetDifficulty(Difficulty difficulty)
    {
        currentDifficulty = difficulty;
        SetPref(DIFFICULTY_PREF, (int)difficulty);
    }

    #endregion

    #region Audio

    public void OnChangeSoundVolume(Single value)
    {
        SetPref(SFX_VOLUME_PREF, value);
    }

    public void OnChangeMusicVolume(Single value)
    {
        SetPref(MUSIC_VOLUME_PREF, value);
    }

    public void OnChangeVoiceVolume(Single value)
    {
        SetPref(VO_VOLUME_PREF, value);
    }

    #endregion

    #region Misc

    public void OnToggleTips(bool state)
    {
        if (state)
        {
            SetPref(TIPS_PREF, state);
        }
    }

    public void OnToggleBloom(bool state)
    {
        if (state)
        {
            SetPref(BLOOM_PREF, state);
        }
    }

    #endregion

    #region Pref Setters and Getters

    #region Pref Setters

    private void SetPref(string key, float value)
    {
        PlayerPrefs.SetFloat(key, value);
    }

    private void SetPref(string key, string value)
    {
        PlayerPrefs.SetString(key, value);
    }

    private void SetPref(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
    }

    private void SetPref(string key, bool value)
    {
        PlayerPrefs.SetInt(key, Convert.ToInt32(value));
    }

    #endregion

    #region Pref Getters

    private bool GetBoolPref(string key, bool defaultValue = true)
    {
        return Convert.ToBoolean(PlayerPrefs.GetInt(key, Convert.ToInt32(defaultValue)));
    }

    #endregion

    #endregion
}
