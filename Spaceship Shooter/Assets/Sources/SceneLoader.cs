using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private void Start()
    {
        Player.Instance.OnPlayerDie += () => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
