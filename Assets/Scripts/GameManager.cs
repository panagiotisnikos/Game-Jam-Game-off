using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int lives = 3;

    public void LoseOneLife()
    {
        lives-=1;
        Debug.Log("Lives left: " + lives);
        if(lives < 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        Debug.Log("DEATH");
    }
}