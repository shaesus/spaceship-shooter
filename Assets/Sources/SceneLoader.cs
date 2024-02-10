using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private void Start()
    {
        Player.Instance.PlayerDie += () => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
