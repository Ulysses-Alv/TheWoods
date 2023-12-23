using UnityEngine;

public class InputGameManager : MonoBehaviour
{
    [SerializeField] private PlayerInputAction playerInput;

    private void Awake()
    {
        playerInput = new PlayerInputAction();

        playerInput.player.Enable();
    }
   
    private void Update()
    {
        if (GameStateManager.instance.state.Value != GameStates.InGame) return;

        Vector2 input = playerInput.player.Movement.ReadValue<Vector2>();

        PlayerController.instance.Move(input);
    }
}

public enum GameStates
{
    InGame, Win, Pause, Lose
}