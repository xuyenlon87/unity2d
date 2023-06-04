using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public Sounds[] sounds;
    public bool isSoundEnabled;
    public GameObject SoundOff;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        // Kiểm tra và khôi phục trạng thái âm thanh từ PlayerPrefs
        isSoundEnabled = PlayerPrefs.GetInt("SoundEnabled", 1) == 1;
        foreach (Sounds s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.audioClip;
            s.source.volume = isSoundEnabled ? s.volume : 0f;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
        if (SoundOff != null)
        {
            SoundOff.SetActive(!isSoundEnabled);
        }

    }

    public void Play(string sound)
    {
        Sounds s = Array.Find(sounds, item => item.name == sound);
        s.source.Play();
    }

    public void Stop(string sound)
    {
        Sounds s = Array.Find(sounds, item => item.name == sound);
        s.source.Stop();
    }

    public void ToggleSound()
    {
        isSoundEnabled = !isSoundEnabled; // Đảo ngược trạng thái âm thanh

        // Lưu trạng thái âm thanh vào PlayerPrefs hoặc bất kỳ phương thức lưu trữ dữ liệu nào khác
        PlayerPrefs.SetInt("SoundEnabled", isSoundEnabled ? 1 : 0);
        PlayerPrefs.Save();

        // Điều chỉnh trạng thái phát/tắt âm thanh cho tất cả các âm thanh trong AudioManager
        foreach (Sounds s in sounds)
        {
            s.source.volume = isSoundEnabled ? s.volume : 0f; // Đặt âm lượng phù hợp với trạng thái âm thanh
        }

        if (SoundOff != null)
        {
            SoundOff.SetActive(!isSoundEnabled);
        }
    }
}
