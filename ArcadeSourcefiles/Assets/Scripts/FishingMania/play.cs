using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class play : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        //gameObject.SetActive(true);
    }
    /*
    public void click()
    {
        Application.LoadLevel("FishingMania_EverythingWorks");
        //SceneManager.LoadScene("sick");
    }
    */

    // Update is called once per frame
    void Update()
    {

    }

    public void loadScene()
    {
    
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void loadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}