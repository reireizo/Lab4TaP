using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject meteorPrefab;
    public GameObject bigMeteorPrefab;

    GameObject player;
    GameObject bigMeteor;

    public bool gameOver = false;

    public int meteorCount = 0;
    public int bigMeteorCount = 0;

    // Start is called before the first frame update
    void OnEnable()
    {
        PlayerInput.onRestart += RestartGame;
    }

    void OnDisable()
    {
        PlayerInput.onRestart -= RestartGame;
    }
    void Awake()
    {
        player = Instantiate(playerPrefab, transform.position, Quaternion.identity);
        CameraManager.instance.player = player.transform;
        InvokeRepeating("SpawnMeteor", 1f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            CancelInvoke();
        }

        if (meteorCount == 5)
        {
            BigMeteor();
        }
    }

    void SpawnMeteor()
    {
        Instantiate(meteorPrefab, new Vector3(Random.Range(-8, 8), 7.5f, 0), Quaternion.identity);
        if (bigMeteorCount == 0)
        {
            CameraManager.instance.SwitchCamera(CameraType.PlayerCamera);
            
        }
    }

    void BigMeteor()
    {
        meteorCount = 0;
        Instantiate(bigMeteorPrefab, new Vector3(Random.Range(-8, 8), 7.5f, 0), Quaternion.identity);
        CameraManager.instance.SwitchCamera(CameraType.BossCamera);
        bigMeteorCount++;
    }

    void RestartGame()
    {
        if (gameOver) 
        {
            SceneManager.LoadScene("Week5Lab");
        }
    }
}
