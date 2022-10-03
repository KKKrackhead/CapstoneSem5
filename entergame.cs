using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class entergame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            //SceneManager.LoadScene(1);
            StartCoroutine(ChangeScene());
        }
    }

    private IEnumerator ChangeScene()
    {
        GetComponent<Animator>().SetTrigger("death");
        yield return new WaitForSeconds(0.6f);
        SceneManager.LoadScene(1);
    }
}
