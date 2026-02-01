using UnityEngine;

using UnityEngine.SceneManagement;
public class DefaultOpen : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void LoadDefaultScene()
        {
            Debug.Log("Button Pressed");
            SceneManager.LoadScene("DefaultOpen");
        }

    // Update is called once per frame
    void Update()
    {
        
    }
}
