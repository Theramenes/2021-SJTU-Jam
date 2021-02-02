using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Audio/Basic Audio Clip")]
public class AudioClipSO : ScriptableObject
{
	public AudioClip clip;

	[Range(0.0f, 2.0f)]
	public float volume;


	[Range(0.0f, 2.0f)]
	public float pitch;

	//	public RangedFloat volume;

	//	[MinMaxRange(0, 2)]
	//	public RangedFloat pitch;

	public void Play(AudioSource source)
    {
		if (clip == null) return;

		source.clip = clip;
		source.volume = volume;
		source.pitch = pitch;

		source.Play();
	}

}