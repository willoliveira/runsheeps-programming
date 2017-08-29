using UnityEngine;
using UnityEngine.UI;
using System.Collections;


// TODO: FAZER UM METODO GENERICO PARA POP UP
public class GameMain : MonoBehaviour
{

    #region PUBLIC VARS
    public Player player;
    #endregion

    #region PRIVATE VARS
    private GameScreen gameReference;
    //flag de inicio de jogo
    private bool flagInitGame = false;
    #endregion

    void Update()
    {
        if (flagInitGame && !GameManager.Pause)
        {
            UpdateChar();
        }
    }

    #region PUBLIC_METHODS
    /// <summary>
    /// Inicializa o game
    /// </summary>
    public void InitGame()
    {
        //seta o inicio do jogo
        flagInitGame = true;
    }
    #endregion

    #region PRIVATE_METHODS
    private void UpdateChar()
    {
        if (Input.GetButtonDown("Jump") || Input.touchCount > 0)
        {
            player.JumpAction();
        }
    }
    #endregion

}
