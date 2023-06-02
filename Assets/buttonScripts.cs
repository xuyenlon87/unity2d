using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonScripts : MonoBehaviour

{
    public GameObject AdsScreen;
    public void OnOpenGameScreen()
    {
        SceneManager.LoadScene("openGameScreen");
    }
    public void OnAdsScreen()
    {
        AdsScreen.SetActive(true);
    }
    public void OffAdsScreen()
    {
        AdsScreen.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        AdsScreen.SetActive(false);
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
