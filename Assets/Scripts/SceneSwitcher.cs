using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour {

	public void SwitchScene () {
		int nextLevel = (SceneManager.GetActiveScene ().buildIndex + 1) % (SceneManager.sceneCount + 1);
		SceneManager.LoadScene (nextLevel);
		print ("Current level " + SceneManager.GetActiveScene ().buildIndex);
		print ("Next level: " + nextLevel);
		print ("Scene count: " + SceneManager.sceneCount);
	}
}
