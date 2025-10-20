using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeExample : MonoBehaviour
{
    // �ش� ��ü�� �ı����� �ʵ��� ����
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // ������Ʈ���� �Է� �޾Ƽ� �� ��ȯ�ϵ��� ����
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
