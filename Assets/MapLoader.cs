using UnityEngine;
using UnityEngine.SceneManagement;

public class MapLoader:MonoBehaviour
{
    public int mapCost;
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

    public void buttonUnlock(int map)
    {
        if(SciptsHomeScreen.scoreTotalCrown - mapCost >= 0)
        GameObject.Find("ButtonUnlock" + map).SetActive(false);

    }
}
