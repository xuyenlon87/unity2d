using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class IAPManager : MonoBehaviour
{
    private string Gift1 = "com.DefaultCompany.unityt2d.Gift1";
    private string Gift2 = "com.DefaultCompany.unityt2d.Gift2";
    private string Gift3 = "com.DefaultCompany.unityt2d.Gift3";
    private string Gift4 = "com.DefaultCompany.unityt2d.Gift4";
    private string Gift5 = "com.DefaultCompany.unityt2d.Gift5";
    private string Gift6 = "com.DefaultCompany.unityt2d.Gift6";

    public void OnPurchaseComplete(Product product)
    {
        if(product.definition.id == Gift1)
        {
            Debug.Log("gift1");
        }
        else if (product.definition.id == Gift2)
        {
            Debug.Log("gift2");
        }
        else if (product.definition.id == Gift3)
        {
            Debug.Log("gift3");
        }
        else if (product.definition.id == Gift4)
        {
            Debug.Log("gift4");
        }
        else if (product.definition.id == Gift5)
        {
            Debug.Log("gift5");
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
