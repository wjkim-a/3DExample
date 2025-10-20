using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeExample : MonoBehaviour
{
    // 해당 객체가 파괴되지 않도록 설정
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // 업데이트에서 입력 받아서 씬 전환하도록 설정
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Alpha1))
            SceneManager.LoadScene(0);
        if (Input.GetKeyUp(KeyCode.Alpha2))
            SceneManager.LoadScene(1);
        if (Input.GetKeyUp(KeyCode.Alpha3))
            SceneManager.LoadScene(2);
    }
}
