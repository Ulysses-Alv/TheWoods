using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;


public class CreateMap : MonoBehaviour
{
    [SerializeField] private GameObject[] floors;
    [SerializeField] private GameObject[] trees;
    [SerializeField] private GameObject[] grass;

    [SerializeField] private Grid grid;

    [SerializeField] private Transform floorParent;
    [SerializeField] private Transform treeParent;
    [SerializeField] private Transform grassParent;

    [SerializeField] private List<GameObject> floorsMap = new List<GameObject>();
    [SerializeField] private List<GameObject> treesMap = new List<GameObject>();
    [SerializeField] private List<GameObject> grassMap = new List<GameObject>();

    public List<GameObject> _floorsMap => floorsMap;

    [Range(10, 100)]
    [SerializeField] private int sizeX, sizeY;

    [Range(1, 10)]
    [SerializeField] private int multiplicator;

    public static CreateMap instance;

    private void Awake()
    {
        instance = this;
    }

    [ContextMenu("Crear Mapa")]
    public void CreateMapa()
    {
        floorsMap.ForEach((floor) => DestroyImmediate(floor));
        treesMap.ForEach((tree) => DestroyImmediate(tree));
        grassMap.ForEach((grass) => DestroyImmediate(grass));

        floorsMap = new List<GameObject>();
        treesMap = new List<GameObject>();
        grassMap = new List<GameObject>();

        for (int x = 0; x < sizeX; x++)
        {
            for (int y = 0; y < sizeY; y++)
            {
                CreateSoil(x, y);
                for (int i = 0; i < multiplicator; i++)
                {
                    CreateTrees(x, y);
                    CreateGrass(x, y);
                }
            }
        }
    }

    void CreateSoil(int x, int y)
    {
        GameObject floor = Instantiate(GetRandomFloor(), grid.GetCellCenterWorld(new Vector3Int(x, y, 0)), Quaternion.identity, floorParent);
        floorsMap.Add(floor);
    }

    void CreateTrees(int x, int y)
    {
        Vector3 pos = GetRandomPosition(grid.GetCellCenterWorld(new Vector3Int(x, y, 0)));
        GameObject tree = Instantiate(GetRandomTree(), pos, Quaternion.identity, treeParent);
        treesMap.Add(tree);
    }

    void CreateGrass(int x, int y)
    {
        Vector3 pos = GetRandomPosition(grid.GetCellCenterWorld(new Vector3Int(x, y, 0)));
        GameObject grass = Instantiate(GetRandomGrass(), pos, Quaternion.identity, grassParent);
        grassMap.Add(grass);
    }

    private GameObject GetRandomFloor()
    {
        return floors[Random.Range(0, floors.Length)];
    }
    private GameObject GetRandomTree()
    {
        return trees[Random.Range(0, trees.Length)];
    }
    private GameObject GetRandomGrass()
    {
        return grass[Random.Range(0, grass.Length)];
    }
    private Vector3 GetRandomPosition(Vector3 vector3)
    {
        float x = Random.Range(vector3.x - 3.5f, vector3.x + 3.5f);
        float y = 0.55f;
        float z = Random.Range(vector3.z - 3.5f, vector3.z + 3.5f);

        Vector3 result = new Vector3(x, y, z);

        return result;
    }
}
