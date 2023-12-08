using System;
using Interfaces;
using GameStates;
using Microsoft.Xna.Framework;

public class GameStateController
{
    public IGameState gameState;
    public GameStateController(Game1 game)
    {
        gameState = new GamePlayState(this, game);
        //gameState = new BoshRushState(this, game);
    }
    public void GamePlay()
    {
        gameState.GamePlay();
    }
    public void Inventory()
    {
        gameState.Inventory();
    }
    public void GameOver()
    {
        gameState.GameOver();
    }
    public void Pause()
    {
        gameState.Pause();
    }
    public void WinGame()
    {
        gameState.WinGame();
    }
    public void TransitionUp()
    {
        gameState.TransitionUp();
    }
    public void TransitionDown()
    {
        gameState.TransitionDown();
    }
    public void TransitionLeft()
    {
        gameState.TransitionLeft();
    }
    public void TransitionRight()
    {
        gameState.TransitionRight();
    }

    public void EnemiesPause() { 
       gameState.EnemiesPause();
    }
    
}

