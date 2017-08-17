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

    private bool pauseBefore;
    private bool pauseLater;
    #endregion


    void Update()
    {
        if (flagInitGame && !GameManager.Pause)
        {
            UpdateChars();
        }
    }

    #region PUBLIC_METHODS
    /// <summary>
    /// Inicializa a spawn sheeps
    /// </summary>
    public void InitGame()
    {
        //seta o inicio do jogo
        flagInitGame = true;
    }
    #endregion

    #region PRIVATE_METHODS
    private void UpdateChars()
    {
        if (Input.GetButtonDown("Jump") || Input.touchCount > 0)
        {
            player.JumpAction();
        }
    }
    #endregion

}
