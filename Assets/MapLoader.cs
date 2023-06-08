using UnityEngine;
using UnityEngine.SceneManagement;

public class MapLoader:MonoBehaviour
{
    public int mapCost;
    public int map;

    private void Awake()
    {
            if (PlayerPrefs.GetInt("MapUnlocked" + map) == 1)
            {
            GameObject.Find("ButtonUnlock" + map).SetActive(false);
            }
    }
    public void OnMapClick(int map)
    {
        SceneManager.LoadScene($"Map{map}");

    }

    public void ReplayMap(int currentMap)
    {
        SceneManager.LoadScene("map" + currentMap.ToString());
    }

    public void mapNext(int currentMap)
    {
        if (PlayerPrefs.GetInt("MapUnlocked" + map) == 1)
        {
            currentMap++;
            SceneManager.LoadScene("map" + currentMap.ToString());
        }
        else
        {
            SceneManager.LoadScene("homeScreen");
        }

    }
    private void Start()
    {
        //unLock = false;
    }

    public void buttonUnlock(int map)
    {
        if (Score.scoreTotalCrown - mapCost >= 0)
        {
            Score.scoreTotalCrown -= mapCost;
            Score.setScoreCrown();
            GameObject.Find("ButtonUnlock" + map).SetActive(false);
            PlayerPrefs.SetInt("MapUnlocked" + map, 1); // Lưu trạng thái đã mở khóa của map
            PlayerPrefs.Save();
        }
    }
}
