using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiController : MonoBehaviour
{
    #region Singleton
    public static UiController Instance;
    private void Awake() => Instance = this;
    #endregion
    
    [SerializeField] private TextMeshProUGUI _itemCounterText;
    [SerializeField] private Button _restartButton;

    private void Start() => _restartButton.onClick.AddListener(RestartLevel);

    public void SetCount(int count)
    {
        _itemCounterText.text = count.ToString();
        if (count == 4) {
            _restartButton.gameObject.SetActive(true);
        }
    }

    private void RestartLevel() => SceneManager.LoadScene(0);
}