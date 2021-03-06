using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBehavior : MonoBehaviour
{
    public bool showWinScreen = false;
    public string labelText = "Collect all 4 items and win your freedom!";
    public int maxItems = 4;

    public int GUIFontSize = 18;
    private GUIStyle guiStyle = new GUIStyle();

    private int _itemsCollected = 0;
    public int Items
    {
        get { return _itemsCollected; }
        set
        {
            _itemsCollected = value;
            Debug.LogFormat("Items: {0}", _itemsCollected);

            if (_itemsCollected >= maxItems)
            {
                labelText = "You've found all the items!";
                showWinScreen = true;
                Time.timeScale = 0f;
            }
            else
            {
                labelText = "Item found, only " + (maxItems - _itemsCollected) + " more to go!";
            }
        }
    }

    private int _playerHP = 10;
    public int HP
    {
        get { return _playerHP; }
        set
        {
            _playerHP = value;
            Debug.LogFormat("Lives: {0}", _playerHP);
        }
    }

    void OnGUI()
    {

        guiStyle = new GUIStyle(GUI.skin.box);
        guiStyle.fontSize = GUIFontSize;
        GUI.Box(new Rect(20, 20, 300, 50), "Player Health:" + _playerHP, guiStyle);
        GUI.Box(new Rect(20, 80, 300, 50), "Items Collected:" + _itemsCollected, guiStyle);


        guiStyle = new GUIStyle(GUI.skin.label);
        guiStyle.fontSize = GUIFontSize;
        GUI.Label(new Rect(Screen.width / 2 - 250, Screen.height - 50, 600, 50), labelText, guiStyle);

        if (showWinScreen)
        {
            guiStyle = new GUIStyle(GUI.skin.button);
            guiStyle.fontSize = GUIFontSize;
            if (GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 50, 200, 100), "Winner Winner \n Chicken Dinner!", guiStyle))
            {
                SceneManager.LoadScene(0);
                Time.timeScale = 1.0f;
            }
        }
    }
}
