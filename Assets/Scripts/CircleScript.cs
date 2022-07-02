using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircleScript : MonoBehaviour
{
    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}

    public Text p1ScoreText;
    public Text p2ScoreText;
    private int p1Score = 0;
    private int p2Score = 0;

    private int turn = 1; // 1 or 2, for P1 and P2
    private Color inactiveColor = new Color(0.75f, 0.75f, 0.75f, 1f);
    //private Color activeColor = new Color(1f, 1f, 1f);
    private Color activeColorP1 = new Color(0.854902f, 0.7411765f, 0.3058824f);
    private Color activeColorP2 = new Color(0.09019608f, 0.6666667f, 0.9019608f);

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "CopperMarble" || other.gameObject.tag == "SilverMarble" || other.gameObject.tag == "GoldMarble")
        {
            // Destroy marble and assign points
            //Debug.Log("Marble left circle");
            Destroy(other.gameObject);

            int points = 0;
            if (other.gameObject.tag == "CopperMarble") points = 1;
            else if (other.gameObject.tag == "SilverMarble") points = 2;
            else if (other.gameObject.tag == "GoldMarble") points = 3;

            if (turn == 1)
            {
                p1Score += points;
                p1ScoreText.text = $"P1 Score: {p1Score}";
            }
            else
            {
                p2Score += points;
                p2ScoreText.text = $"P2 Score: {p2Score}";
            }
        }
    }

    public void SwapTurns(int playerNumber)
    {
        if(playerNumber != 1 && playerNumber != 2)
        {
            Debug.Log("Error: playerNumber was expected to be 1 or 2");
            return;
        }

        turn = playerNumber;
        if (playerNumber == 1)
        {
            p1ScoreText.color = activeColorP1;
            p2ScoreText.color = inactiveColor;
        }
        else if (playerNumber == 2)
        {
            p1ScoreText.color = inactiveColor;
            p2ScoreText.color = activeColorP2;
        }
        //Debug.Log("Turns swapped");
    }
}
