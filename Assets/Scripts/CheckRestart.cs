using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckRestart : MonoBehaviour
{
    public static CheckRestart instance;

    public bool bIsRestarted = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }

        DontDestroyOnLoad(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
