using System;

using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Fader : MonoBehaviour
{
	public static Fader Instance { get; private set; }

	public bool Fading { get; private set; }
	public bool FadeInDone { get; private set; }
	public bool FadeOutDone { get; private set; }

	private Animator animator;
	private Action callback;

	private void Awake()
	{
		this.Fading = false;
		this.FadeInDone = false;
		this.FadeOutDone = false;
		this.animator = this.GetComponent<Animator>();

		Fader.Instance = this;
	}

	public void onBeginFadeIn()
	{
		this.Fading = true;
		this.FadeInDone = false;
		this.FadeOutDone = false;
	}

	public void onCompleteFadeIn()
	{
		this.Fading = false;
		this.FadeInDone = true;
		this.callback?.Invoke();
	}

	public void onBeginFadeOut()
	{
		this.Fading = true;
		this.FadeInDone = false;
		this.FadeOutDone = false;
	}

	public void onCompleteFadeOut()
	{
		this.Fading = false;
		this.FadeOutDone = true;
		this.callback?.Invoke();
	}

	public void doFadeIn(Action callback)
	{
		this.callback = callback;

		if (!this.FadeInDone)
			this.animator.SetTrigger("fadeIn");
	}

	public void doFadeOut(Action callback)
	{
		this.callback = callback;

		if (!this.FadeOutDone)
			this.animator.SetTrigger("fadeOut");
	}
}
