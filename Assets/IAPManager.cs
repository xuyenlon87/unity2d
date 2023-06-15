using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class IAPManager : MonoBehaviour
{
    private string Gift1 = "com.defaultcompany.unityt2d.gift1";
    private string Gift2 = "com.defaultcompany.unityt2d.gift2";
    private string Gift3 = "com.defaultcompany.unityt2d.gift3";
    private string Gift4 = "com.defaultcompany.unityt2d.gift4";
    private string Gift5 = "com.defaultcompany.unityt2d.gift5";
    private string Gift6 = "com.defaultcompany.unityt2d.gift6";

    public void OnPurchaseComplete(Product product)
    {
        if(product.definition.id == Gift1)
        {
            Debug.Log("gift1");
            Score.scoreTotalCrown += 10;
            Score.setScoreCrown();
            Score.setScoreStar();
        }
        else if (product.definition.id == Gift2)
        {
            Debug.Log("gift2");
            Score.scoreTotalCrown += 25;
            Score.setScoreCrown();
            Score.setScoreStar();
        }
        else if (product.definition.id == Gift3)
        {
            Debug.Log("gift3");
            Score.scoreTotalCrown += 25;
            Score.scoreTotal += 20;
            Score.setScoreCrown();
            Score.setScoreStar();
        }
        else if (product.definition.id == Gift4)
        {
            Debug.Log("gift4");
            Score.scoreTotalCrown += 50;
            Score.setScoreCrown();
            Score.setScoreStar();
        }
        else if (product.definition.id == Gift5)
        {
            Debug.Log("gift5");
            Score.scoreTotalCrown += 50;
            Score.scoreTotal += 100;
            Score.setScoreCrown();
            Score.setScoreStar();
        }
        else if (product.definition.id == Gift6)
        {
            Debug.Log("gift6");
        }
    }

    public void OnPurchaseFailure(Product product, PurchaseFailureReason reason)
    {
        Debug.Log("failed" + reason);
    }

}
