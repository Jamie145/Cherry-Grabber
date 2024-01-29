using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Restart : MonoBehaviour
{
    // Start is called before the first frame update
    public void Beginning()
    {
        SceneManager.LoadScene(0);
        Debug.Log("Button pushed");
    }

  
}
