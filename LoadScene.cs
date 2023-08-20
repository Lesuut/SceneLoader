/*using System.Collections;
using System.Collections.Generic;*/
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public static Text txtProgress;
    public static GameObject objChild;

    public static LoadScene instance;
    private AsyncOperation laodadingSceneOperation;

    private void Start()
    {
        instance = this;

        objChild = transform.GetChild(0).gameObject;
        GameObject txtObj = objChild.transform.GetChild(0).gameObject;
        txtProgress = txtObj.GetComponent<Text>();       
    }

    public static void Load(int idScene)
    {
        objChild.SetActive(true);
        instance.laodadingSceneOperation = SceneManager.LoadSceneAsync(idScene);
        instance.laodadingSceneOperation.allowSceneActivation = false;      
    }
    private void Update()
    {
        if (instance.laodadingSceneOperation != null)
        {
            txtProgress.text = Mathf.RoundToInt(instance.laodadingSceneOperation.progress * 100) + 9 + "%";

            if (instance.laodadingSceneOperation.progress > 0.89)
            {
                instance.laodadingSceneOperation.allowSceneActivation = true;
            }
        }
    }   
}
