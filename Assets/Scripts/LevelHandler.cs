using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHandler : MonoBehaviour
{
    public static LevelHandler instance;

    [Header("Floor Data")]
    public int floorsCount;
    public GameObject floorPrefab;
    public Transform floorsParent;
    public float floorSpacing;

    [Header("Wall Data")]
    public GameObject wallPrefab;
    [Range(1, 10)]
    public int wallHeightMax = 1;
    [Range(1, 8)]
    public int wallWidthMax = 1;

    [Header("Collectable Data")]
    public GameObject collectablePrefab;
    [Range(1, 15)]
    public int collectableHeightMax = 1;

    [Header("Food Data")]
    public GameObject foodPrefab;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        //CreateNewLevel();
    }
    [ContextMenu("Create Level")]
    void CreateNewLevel()
    {
        List<GameObject> kids = new List<GameObject>();
        for (int i = 0; i < floorsParent.childCount; i++)
        {
            kids.Add(floorsParent.GetChild(i).gameObject);
        }
        foreach (var item in kids)
        {
            DestroyImmediate(item);
        }
        if (floorsParent.childCount > 0) return;
        for (int i = 0; i < floorsCount; i++)
        {
            GameObject floor = Instantiate(floorPrefab, floorsParent);
            floor.transform.localPosition = new Vector3(0, -4, i * floorSpacing);
            if (i > 0)
            {
                MakeWall(floor.transform, Random.Range(1, wallHeightMax + 1), Random.Range(1, wallWidthMax + 1));
                //MakeWall(floor.transform, 1, 3);
            }
        }
    }

    void MakeWall(Transform _floor, int _wallHeight, int _wallWidth)
    {
        if (_wallWidth <= 0) return;
        float xDiff = 0.125f;
        float zPos = Random.Range(-0.45f, 0.45f);
        if (_wallWidth % 2 == 0)
        {
            for (int j = 0; j < _wallHeight; j++)
            {
                for (int i = 0; i < _wallWidth / 2; i++)
                {
                    GameObject wallObj = Instantiate(wallPrefab);
                    wallObj.transform.SetParent(_floor);
                    wallObj.transform.localPosition = new Vector3(0.06f + (xDiff * i), j + 1, zPos);
                }
                for (int i = 0; i < _wallWidth / 2; i++)
                {
                    GameObject wallObj = Instantiate(wallPrefab);
                    wallObj.transform.SetParent(_floor);
                    wallObj.transform.localPosition = new Vector3(-0.06f + (-xDiff * i), j + 1, zPos);
                }
            }
        }
        else
        {
            for (int j = 0; j < _wallHeight; j++)
            {
                GameObject wallObj01 = Instantiate(wallPrefab);
                wallObj01.transform.SetParent(_floor);
                wallObj01.transform.localPosition = new Vector3(0, j + 1, zPos);
                for (int i = 0; i < (_wallWidth - 1) / 2; i++)
                {
                    GameObject wallObj = Instantiate(wallPrefab);
                    wallObj.transform.SetParent(_floor);
                    wallObj.transform.localPosition = new Vector3(xDiff + (xDiff * i), j + 1, zPos);
                }
                for (int i = 0; i < (_wallWidth - 1) / 2; i++)
                {
                    GameObject wallObj = Instantiate(wallPrefab);
                    wallObj.transform.SetParent(_floor);
                    wallObj.transform.localPosition = new Vector3(-xDiff + (-xDiff * i), j + 1, zPos);
                }
            }
        }
    }
}
