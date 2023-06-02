using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score = 0;
    public int scoreCrown = 0;
    public Text starCoinScore;
    public GameObject crownAfter;
    public GameObject finishMapScreen;
    public GameObject flagOn;
    public GameObject flag;
    public GameObject offGameControl;
    public static int scoreTotal = 0;
    public static int scoreTotalCrown = 0;
    //public Text ScoreTotal;
    public bool dkWin;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("starCoin"))
        {
            score++;
            starCoinScore.text = score.ToString() + "/3";
            //StarCoinScore.IncreaseScore(3);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("crownCoin"))
        {
            scoreCrown++;
            Destroy(collision.gameObject);

            crownAfter.SetActive(true);
            scoreTotalCrown += scoreCrown;
        }
        else if (collision.gameObject.CompareTag("flag"))
        {
            
            if (score >= 3)
            {
                //finishMapScreen.SetActive(true);
                //flagOn.SetActive(true);
                //flag.SetActive(false);
                //scoreTotal += score;
                //ScoreTotal.text = scoreTotal.ToString();
                dkWin = true;
                scoreTotal += score;

            }
        }
        

    }
    
    
 
    // Start is called before the first frame update
    void Start()
    {
        starCoinScore = GameObject.Find("starCoinScore").GetComponent<Text>();
        dkWin = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (dkWin)
        {
            finishMapScreen.SetActive(true);
            flagOn.SetActive(true);
            flag.SetActive(false);
            //ScoreTotal.text = scoreTotal.ToString();
        }
    }
}
