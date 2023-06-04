using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicManager : MonoBehaviour
{
    public static musicManager instance;
    public AudioSource backgroundMusic;
    public bool isMusicEnabled;
    public GameObject MusicOff;
    // Start is called before the first frame update

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

        // Kiểm tra và khôi phục trạng thái âm nhạc từ PlayerPrefs
        isMusicEnabled = PlayerPrefs.GetInt("MusicEnabled", 1) == 1;

        // Thiết lập trạng thái âm nhạc ban đầu
        if (isMusicEnabled)
        {
            PlayBackgroundMusic();
        }
        else
        {
            StopBackgroundMusic();
        }
        if (MusicOff != null)
        {
            MusicOff.SetActive(!isMusicEnabled);
        }
    }

    public void ToggleMusic()
    {
        isMusicEnabled = !isMusicEnabled; // Đảo ngược trạng thái âm nhạc

        // Lưu trạng thái âm nhạc vào PlayerPrefs hoặc bất kỳ phương thức lưu trữ dữ liệu nào khác
        PlayerPrefs.SetInt("MusicEnabled", isMusicEnabled ? 1 : 0);
        PlayerPrefs.Save();

        // Điều chỉnh trạng thái phát/tắt âm nhạc
        if (isMusicEnabled)
        {
            PlayBackgroundMusic();
        }
        else
        {
            StopBackgroundMusic();
        }

        // Hiển thị hoặc ẩn đối tượng MusicOff tương ứng với trạng thái âm nhạc
        if (MusicOff != null)
        {
            MusicOff.SetActive(!isMusicEnabled);
        }
    }

    private void PlayBackgroundMusic()
    {
        if (backgroundMusic != null)
        {
            backgroundMusic.Play();
        }
    }

    private void StopBackgroundMusic()
    {
        if (backgroundMusic != null)
        {
            backgroundMusic.Stop();
        }
    }
}
