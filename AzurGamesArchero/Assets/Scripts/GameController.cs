using UnityEngine;

public class GameController : MonoBehaviour
{
    static GameController _instance;
    public static GameController Instance
    {
        get
        {
            if (_instance == null)
                FindObjectOfType<GameController>();

            return _instance;
        }
    }

    
}
