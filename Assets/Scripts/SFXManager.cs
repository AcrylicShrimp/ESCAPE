using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SFXManager : MonoBehaviour
{
	public static SFXManager Instance { get; private set; }

	[SerializeField]
	private AudioClip[] _walkSFXs;
	[SerializeField]
	private AudioClip _doorSFX;
	
	private AudioSource audioSource;

	private void Awake()
	{
		this.audioSource = this.GetComponent<AudioSource>();

		SFXManager.Instance = this;
	}

	public void playWalk()
	{
		int n = Random.Range(1, this._walkSFXs.Length);
		var clip = this._walkSFXs[n];
		this.audioSource.PlayOneShot(clip);
		this._walkSFXs[n] = this._walkSFXs[0];
		this._walkSFXs[0] = clip;
	}

	public void playDoor()
	{
		this.audioSource.PlayOneShot(this._doorSFX);
	}
}
