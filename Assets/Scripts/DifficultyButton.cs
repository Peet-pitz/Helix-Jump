using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    private PlayerController playerController;
    //private Button button;
    //public int difficulty;
    public GameObject[] difficulties;
    private int selecteddifficulty = 0;

    // Start is called before the first frame update
    void Start()
    {
        /*button = GetComponent<Button>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        button.onClick.AddListener(SetDifficulty);*/

        foreach (GameObject ch in difficulties)
        {
            ch.SetActive(false);
        }
        difficulties[selecteddifficulty].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeDifficulty(int newCharacter)
    {
        difficulties[selecteddifficulty].SetActive(false);
        difficulties[newCharacter].SetActive(true);
        selecteddifficulty = newCharacter;
    }

    /*void SetDifficulty()
    {
        playerController.GameDifficulty(difficulty);
    }*/
}
