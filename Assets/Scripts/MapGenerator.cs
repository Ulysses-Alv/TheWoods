using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MapGenerator : MonoBehaviour
{
    private void Start()
    {
        CreateMap.instance.CreateMapa();
    }
}
