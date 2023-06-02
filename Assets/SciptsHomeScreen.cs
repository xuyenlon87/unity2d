using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SciptsHomeScreen : MonoBehaviour
{
    public int scoreTotal;
    public static int scoreTotalCrown;
    public Text TextScore;
    public Text TextScoreCrown;
    // Start is called before the first frame update
    void Start()
    {
        scoreTotal = Score.scoreTotal;
        scoreTotalCrown = Score.scoreTotalCrown;
    }

    // Update is called once per frame
    void Update()
    {
        scoreTotal = Score.scoreTotal;
        TextScore.text = scoreTotal.ToString();
        scoreTotalCrown = Score.scoreTotalCrown;
        TextScoreCrown.text = scoreTotalCrown.ToString();
        
    }
}
