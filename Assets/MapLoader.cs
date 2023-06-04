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
    public void OnMapClick(int map)
    {
        SceneManager.LoadScene($"Map{map}");

    }

    public void ReplayMap(int mapReplay)
    {
        SceneManager.LoadScene("map" + mapReplay.ToString());
    }

    public void mapNext(int currentMap)
    {
        
        currentMap++;
        SceneManager.LoadScene("map" + currentMap.ToString());
    }
    private void Start()
    {
        unLock = false;
    }

    public void buttonUnlock(int map)
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
