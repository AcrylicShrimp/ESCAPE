using UnityEngine;

public class GameExiter : MonoBehaviour
{
	public void exit()
	{
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#else
		Application.Quit();
#endif
	}
}
