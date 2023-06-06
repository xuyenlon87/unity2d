using UnityEngine;
using UnityEngine.SceneManagement;

public class MapLoader:MonoBehaviour
{
    public int mapCost;
    public bool unLock;
    public int map;

    private void Awake()
    {
            if (PlayerPrefs.GetInt("Map Unlocked") == 1)
            {
                unLock = true; // Cập nhật trạng thái đã mở khóa của map tương ứng
                GameObject.Find("ButtonUnlock" + map).SetActive(false);
            }
    }
    public void OnMapClick()
    {
        SceneManager.LoadScene($"Map{map}");

    }

    public void ReplayMap()
    {
        SceneManager.LoadScene("map" + map.ToString());
    }

    public void mapNext()
    {
        if (unLock)
        {
            map++;
            SceneManager.LoadScene("map" + map.ToString());
        }
        else
        {
            SceneManager.LoadScene("homeScreen");
        }

    }
    private void Start()
    {
        unLock = false;
    }

    public void buttonUnlock()
    {
        if (SciptsHomeScreen.scoreTotalCrown - mapCost >= 0)
        {
            GameObject.Find("ButtonUnlock" + map).SetActive(false);
            unLock = true;
            PlayerPrefs.SetInt("Map Unlocked", 1); // Lưu trạng thái đã mở khóa của map
            PlayerPrefs.Save();
        }
    }
}
