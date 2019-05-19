using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region singleton
    public GameObject[] HealthBar;
    public static GameManager instance;
    private int healthPlayer;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);


    }
    #endregion

    public string[] sceneToLoad;
    
    public void LoadScene(int index)
    {
        SceneManager.LoadSceneAsync(index);
    }

    private void Update()
    {
        healthPlayer = CharacterController.instance.character.GetComponent<Character>().playerHealth;//Cari player health di character controller script 
        hearthUI();//Manggil Method buat update UI health Bar
    }

    void hearthUI()//Method Update UI Health Bar
    {
        for (int i = 0; i < HealthBar.Length; i++)
        {
            if (healthPlayer == 4)
            {
                HealthBar[i].SetActive(true);
            }
            else if (healthPlayer < 4)
            {
                for (int j = 0; j < HealthBar.Length; j++)
                {
                    HealthBar[j].SetActive(false);
                }

                for (int l = 0; l < healthPlayer; l++)
                {
                    HealthBar[l].SetActive(true);
                }
            }
        }
    }
}