using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopMenu : MonoBehaviour
{

    public BuildLevel buildLevel;
    public Player player;
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject buttoncost1;
    public GameObject buttoncost2;
    public GameObject buttoncost3;
    private Color grayedOut;
    private Color normalColor;
    private int cost1 = 3;
    private int cost2 = 3;
    private int cost3 = 3;

    private void Start() {
        buildLevel = GameObject.Find("World").GetComponent<BuildLevel>();
        player = buildLevel.player.GetComponent<Player>();
        UpdateShop();
    }

    public void UpdateShop() {
        if (!player) {
            player = buildLevel.player.GetComponent<Player>();
        }

        if(player.coins < cost1) {
            button1.GetComponent<Button>().interactable = false;
        }
        if(player.coins < cost2) {
            button2.GetComponent<Button>().interactable = false;
        }
        if(player.coins < cost3) {
            button3.GetComponent<Button>().interactable = false;
        }
        if(player.speed >= 8) {
            buttoncost1.GetComponent<TMPro.TextMeshProUGUI>().text = "MAX";
        }
        if(player.range >= 9) {
            buttoncost2.GetComponent<TMPro.TextMeshProUGUI>().text = "MAX";
        }
        if(player.lives >= 5) {
            buttoncost3.GetComponent<TMPro.TextMeshProUGUI>().text = "MAX";
        }
    }

    public void Done()
    {
        button1.GetComponent<Button>().interactable = true;
        button2.GetComponent<Button>().interactable = true;
        button3.GetComponent<Button>().interactable = true;

        Debug.Log("Done with shop.");
        buildLevel.nextLevel.Invoke();
    }

    public void BuyUpgrade1()
    {
        if(player.coins >= cost1 && player.speed < 8) {
           player.coins -= cost1;
           player.speed++; 
           Debug.Log("Player coins: " + player.coins);
           Debug.Log("Player speed: " + player.speed);
           cost1++;
           buttoncost1.GetComponent<TMPro.TextMeshProUGUI>().text = "x" + cost1.ToString();
        }
        else {
            Debug.Log("Not enough coins for upgrade 1.");
        }
        player.UpdateText();
        UpdateShop();

    }

    public void BuyUpgrade2()
    {
        if(player.coins >= cost2 && player.range < 9) {
            player.coins -= cost2;
            player.range += 2;
            Debug.Log("Player coins: " + player.coins);
            Debug.Log("Player range: " + player.range);
            cost2++;
            buttoncost2.GetComponent<TMPro.TextMeshProUGUI>().text = "x" + cost2.ToString();

        }
        else {
            Debug.Log("Not enough coins for upgrade 2.");
        }
        player.UpdateText();
        UpdateShop();

    }

    public void BuyUpgrade3()
    {
        if(player.coins >= cost3 && player.lives < 5) {
            player.coins -= cost3;
            player.lives++;
            Debug.Log("Player coins: " + player.coins);
            Debug.Log("Player lives: " + player.lives);
            cost3++;
            buttoncost3.GetComponent<TMPro.TextMeshProUGUI>().text = "x" + cost3.ToString();
        }
        else {
            Debug.Log("Not enough coins for upgrade 3.");
        }
        player.UpdateText();
        UpdateShop();

    }

}
