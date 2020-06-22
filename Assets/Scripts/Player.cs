using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Player : MonoBehaviour
{
	public static Player Instance { get; private set; }

	public enum Direction
	{
		Left,
		Right
	}

	public Direction Dir { get; private set; }

	[SerializeField]
	private float _speed;
	[SerializeField]
	private float _footstep;

	private AudioSource radioStatic;
	private float lastFootstepTime = 0f;

	private void Awake()
	{
		this.Dir = Direction.Right;
		this.radioStatic = this.GetComponent<AudioSource>();

		Player.Instance = this;
	}

	private void Update()
	{
		var movement = Input.GetAxisRaw("Horizontal");

		if (!Fader.Instance.Fading && .5f < Mathf.Abs(movement))
		{
			this.Dir = movement < 0f ? Direction.Left : Direction.Right;
			this.transform.position += Vector3.right * movement * Time.deltaTime * this._speed;
			this.transform.localScale = new Vector3(movement < 0f ? -1f : 1f, 1f, 1f);

			if (this._footstep <= Time.time - this.lastFootstepTime)
			{
				SFXManager.Instance.playWalk();
				this.lastFootstepTime = Time.time;
			}
		}

		if (Enemy.Enemies.Count == 0)
		{
			this.radioStatic.volume = 0f;
			return;
		}

		var minimumDistance = (Enemy.Enemies[0].transform.position - this.transform.position).magnitude;

		for (int index = 1; index < Enemy.Enemies.Count; ++index)
		{
			var distance = (Enemy.Enemies[index].transform.position - this.transform.position).magnitude;

			if (distance < minimumDistance)
				minimumDistance = distance;
		}

		this.radioStatic.volume = Mathf.Pow( Mathf.Max((-minimumDistance + 8f) / 8f, 0f), 2f);
	}
}
