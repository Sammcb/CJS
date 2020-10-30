using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopMenu : MonoBehaviour
{

    public void NextLevel()
    {
        SceneManager.LoadScene("Game");
    }

    public void BuyUpgrade1()
    {
        Debug.Log("Bought upgrade 1.");
    }

    public void BuyUpgrade2()
    {
        Debug.Log("Bought upgrade 2.");
    }

    public void BuyUpgrade3()
    {
        Debug.Log("Bought upgrade 3.");
    }

}
