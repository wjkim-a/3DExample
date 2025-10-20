using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;

    //�ܺ� ȣ��� ������Ƽ, �ش� Ÿ���� �̱����� ������ ã�ƺ��� �׷��� ������ ���� ���� �� ����
    public static T Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<T>();

                if(_instance == null)
                {
                    GameObject singletonObj = new GameObject();
                    _instance = singletonObj.AddComponent<T>();
                    singletonObj.name = typeof(T).ToString();
                }
            }

            return _instance;
        }
    }

    //�ߺ� üũ �� ���� ��� ����
    protected virtual void Awake()
    {
        Debug.Log("awake" + gameObject.name);
        if (_instance == null)
        {
            _instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if(_instance != this)
            {
                Destroy(gameObject);
            }
        }
    }

    private void Start()
    {
        Debug.Log("start" + gameObject.name);
    }
}
