using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopMenu : MonoBehaviour
{

    public BuildLevel buildLevel;
    private Player player;

    private void Awake() {
        buildLevel = GameObject.Find("World").GetComponent<BuildLevel>();
        player = buildLevel.player.GetComponent<Player>();
    }

    public void Done()
    {
        buildLevel.nextLevel.Invoke();
    }

    public void BuyUpgrade1()
    {
        Debug.Log("Bought upgrade 1. Player running speed increasing...");
        player.coins -= 3;
        player.speed++;
        Debug.Log("");
        Debug.Log("");

    }

    public void BuyUpgrade2()
    {
        Debug.Log("Bought upgrade 2. Fire hose range increasing...");
        player.coins -= 3;
        player.range += 2;

    }

    public void BuyUpgrade3()
    {
        Debug.Log("Bought upgrade 3. Adding an extra life...");
        player.coins -= 3;
        player.lives++;
    }

}
