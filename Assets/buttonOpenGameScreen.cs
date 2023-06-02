using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonOpenGameScreen : MonoBehaviour
{
    public GameObject settingScreen;
    public GameObject AdsScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void OnsettingScreen()
    {
        settingScreen.SetActive(true);
    }
    public void OnAdsScreen()
    {
        AdsScreen.SetActive(true);
    }
    public void OffsettingScreen()
    {
        settingScreen.SetActive(false);
    }
    public void OffAdsScreen()
    {
        AdsScreen.SetActive(false);
    }
    public void OnPlay()
    {
        SceneManager.LoadScene("homeScreen");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
