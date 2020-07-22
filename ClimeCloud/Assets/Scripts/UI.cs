using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public GameObject clearPanel;

    // Start is called before the first frame update
    void Start()
    {
        clearPanel = GameObject.Find("Panel");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClick()
    {
        SceneManager.LoadScene("GameScene");
    }
}
