using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class StartSceneUI : MonoBehaviour
{
    [SerializeField] string _sceneName;
    [SerializeField] Canvas _rule;
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
