using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHandler : MonoBehaviour
{
    public static LevelHandler instance;

    public GameObject blockerPrefab;
    [Range(1, 10)]
    public int blockerHeightMax = 1;
    [Range(1, 8)]
    public int blockerWidthMax = 1;
    public GameObject foodPrefab;
    public GameObject collectablePrefab;
    [Range(1, 15)]
    public int collectableHeightMax = 1;
    public GameObject floorPrefab;
    public Transform floorsParent;
    public int levelLength;
    public float floorLength;


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
        CreateNewLevel();
    }

    void CreateNewLevel()
    {
        for (int i = 0; i < levelLength; i++)
        {
            GameObject floor = Instantiate(floorPrefab, floorsParent);
            floor.transform.localPosition = new Vector3(0, -4, i * floorLength);
            if (i > 0)
            {
                
            }
        }
    }

    void MakeWall(int wallHeight, int wallWidth)
    {
        if (wallWidth % 2 == 0)
        {

        }
    }

}
