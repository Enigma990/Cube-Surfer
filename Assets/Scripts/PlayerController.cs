using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private static PlayerController instance;
    public static PlayerController Instance { get { return instance; } }

    [Header("Player Movement")]
    [SerializeField] private float speed = 5f;
    [SerializeField] private float touchSpeed = 5f;

    [Header("Cubes Data")]
    [SerializeField] private GameObject cubePrefab = null;
    [SerializeField] private Transform cubesSpawnPos = null;
    private int cubesIndex = 0;

    private bool b_IsLastCube = true;

    private int score = 0;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        cubesIndex = 0;
        score = 0;

        GameManager.Instance.UpdateScore(score);
    }

    // Update is called once per frame
    void Update()
    {

        //--------------------------------Editor Controls-------------------------------------

#if UNITY_EDITOR

        float _newPosX = transform.position.x + Input.GetAxis("Horizontal") * 5 * Time.deltaTime;

        //Mathf.Clamp(_newPosX, -2f, 2f);

        if (_newPosX > 3.25f)
        {
            _newPosX = 3.25f;
        }

        if (_newPosX < -3.25f)
        {
            _newPosX = -3.25f;
        }

        transform.position = new Vector3(_newPosX,
            transform.position.y, transform.position.z);


#endif

//--------------------------------Touch Controls--------------------------------------

        PlayerMovement();
        transform.Translate(transform.forward * speed * Time.deltaTime);
    }

    void PlayerMovement()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch(touch.phase)
            {
                case TouchPhase.Moved:
                    //transform.position = new Vector3(transform.position.x + touch.deltaPosition.x * touchSpeed * Time.deltaTime, transform.position.y,transform.position.z);

                    float _newPosX = transform.position.x + touch.deltaPosition.x * touchSpeed * Time.deltaTime;

                    if (_newPosX > 3.25f)
                    {
                        _newPosX = 3.25f;
                    }

                    if (_newPosX < -3.25f)
                    {
                        _newPosX = -3.25f;
                    }

                    transform.position = new Vector3(_newPosX,
                        transform.position.y, transform.position.z);


                    //Mathf.Clamp(transform.position.x, -4f, 4f);
                    break;
            }
        }
    }

    public void AddCube()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);

        //_NewCube.transform.position = cubesSpawnPos.position;
        ////_NewCube.transform.SetParent(cubesStack.transform);
        //_NewCube.transform.SetParent(transform);
        //_NewCube.GetComponent<Collider>().isTrigger = false;

        GameObject _NewCube = Instantiate(cubePrefab, cubesSpawnPos.position, Quaternion.identity);
        _NewCube.transform.SetParent(transform);

        cubesSpawnPos.transform.position = new Vector3(cubesSpawnPos.transform.position.x,
            cubesSpawnPos.transform.position.y - 1f, cubesSpawnPos.transform.position.z);

        //cubesSpawnPos.position = new Vector3(transform.position.x, _NewCube.transform.position.y - 1f, transform.position.z);

        cubesIndex++;
    }

    public void RemoveCube()
    {
        cubesSpawnPos.transform.position = new Vector3(cubesSpawnPos.transform.position.x,
            cubesSpawnPos.transform.position.y + 1f, cubesSpawnPos.transform.position.z);

        cubesIndex--;

        if (cubesIndex <= 0)
        {
            b_IsLastCube = true;
        }
    }

    public void UpdateScore()
    {
        score += 1;
        GameManager.Instance.UpdateScore(score);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cube")) 
        {
            b_IsLastCube = false;

            AddCube();
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Wall"))
        {
            speed = 0;
            touchSpeed = 0;

            GameManager.Instance.LevelFailed();
        }

        if (other.CompareTag("Collectables"))
        {
            UpdateScore();
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Finish")) 
        {
            GameManager.Instance.LevelComplete();
        }
    }
}
