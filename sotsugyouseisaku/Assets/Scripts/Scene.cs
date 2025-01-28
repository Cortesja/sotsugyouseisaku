using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scene : MonoBehaviour
{
    [SerializeField] private string nextScene;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(ExChangeScene);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ExChangeScene(){
        SceneManager.LoadScene(nextScene);
    }

}
