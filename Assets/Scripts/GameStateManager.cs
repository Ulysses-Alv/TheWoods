using UniRx;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager instance;
    
    public ReactiveProperty<GameStates> state = new ReactiveProperty<GameStates>(initialValue: GameStates.InGame);


    private void Awake()
    {
        instance = this;
    }
}
