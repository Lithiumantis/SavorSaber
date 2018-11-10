using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour {
	
	public static AudioPlayer main = null; // static global ref
	public bool ready;
	public AudioSource sfx_source;
	public AudioSource bgm_source;
	AssetBundle sfx_bundle;
	AssetBundle bgm_bundle;

	void Awake()
	{
		DontDestroyOnLoad(transform.gameObject);
		if (main == null) main = this;
		else GameObject.Destroy(gameObject); // avoid multiple copies
		ready = false;
	}

	// Use this for initialization
	void Start () {
		sfx_bundle = AssetBundle.LoadFromFile(System.IO.Path.Combine(Application.streamingAssetsPath, "sfx"));
		bgm_bundle = AssetBundle.LoadFromFile(System.IO.Path.Combine(Application.streamingAssetsPath, "bgm"));
		ready = true;
	}

	// play sfx from name with specified volume modifier (finds first open channel)
	public void playSFX(string name, float volume = 1.0F)
	{
		playSFX(sfx_bundle.LoadAsset<AudioClip>(name), volume);
	}
	// play sfx from AudioClip with specified volume modifier (finds first open channel)
	public void playSFX(AudioClip sfx, float volume = 1.0f)
	{
		sfx_source.PlayOneShot(sfx, volume);
	}
		
	// play bgm from name with specified volume modifier (finds first open channel)
	public void playBGM(string name, float volume = 1.0F)
	{
		playBGM(bgm_bundle.LoadAsset<AudioClip>(name), volume);
	}
	// play bgm from AudioClip with specified volume modifier (finds first open channel)
	public void playBGM(AudioClip bgm, float volume = 1.0f)
	{
		bgm_source.clip = bgm;
		bgm_source.volume = volume;
		bgm_source.Play ();
	}

	// Update is called once per frame
	void Update () {
		
	}
}
