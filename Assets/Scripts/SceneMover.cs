using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMover : MonoBehaviour
{
	[SerializeField]
	private string _target;

	public void move()
	{
		if (Fader.Instance.Fading)
			return;

		Fader.Instance.doFadeOut(() => SceneManager.LoadScene(this._target, LoadSceneMode.Single));
	}
}
