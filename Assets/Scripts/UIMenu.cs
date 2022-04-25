using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIMenu : MonoBehaviour
{
    public TMP_InputField inputName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        PlayerInfo.Instance.setName(inputName.text);
        SceneManager.LoadScene(1);
    }

}
