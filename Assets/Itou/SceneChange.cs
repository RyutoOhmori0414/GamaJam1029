using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SceneChange : MonoBehaviour
{
    [SerializeField] string _sceneName;
    [SerializeField] Canvas _rule;
    [SerializeField] Canvas _targetCanvas;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(_sceneName);
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            RuleOnOff();
        }
    }
    public void RuleOnOff()
    {
        _rule.enabled = !_rule.enabled;
    }
}
