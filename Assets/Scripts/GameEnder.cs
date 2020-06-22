using UnityEngine;
using UnityEngine.SceneManagement;

public enum Ending
{
	Alive,
	Dead
}

[RequireComponent(typeof(Collider))]
public class GameEnder : MonoBehaviour
{
	[SerializeField]
	private Ending _ending;

	private void OnTriggerStay(Collider other)
	{
		if (other.tag != "Player")
			return;

		if (Fader.Instance.Fading)
			return;

		if (this._ending == Ending.Alive)
		{
			SFXManager.Instance.playDoor();
			Fader.Instance.doFadeOut(() => SceneManager.LoadScene("Alive", LoadSceneMode.Single));
		}
		else
			SceneManager.LoadScene("Dead", LoadSceneMode.Single);
	}
}
