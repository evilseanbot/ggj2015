using UnityEngine;
using System.Collections;

public class Weather : MonoBehaviour {

	public int timeToChange;
	public int timeToFade;
	public bool isRaining;

	public bool fadingInRainSound;
	public bool fadingOutRainSound;

	public GameObject goldLighting;
	//public GameObject coldLighting;
	public GameObject rainParticles;
	public GameObject rainSound;
	public GameObject lightning;

	// Use this for initialization
	void Start () {
		timeToChange = 300;
		timeToFade = 0;
		isRaining = false;
		fadingInRainSound = false;
		fadingOutRainSound = false;
	}
	
	// Update is called once per frame
	void Update () {
		timeToChange -= 1;

		if (timeToChange <= 0) {
			changeWeather();
		}

		if (fadingInRainSound || fadingOutRainSound) {
			timeToFade -= 1;

			if (fadingInRainSound) {
				rainSound.GetComponent<AudioSource>().volume = (1 - ((float)timeToFade/300f)) * 0.3f;
			}

			if (fadingOutRainSound) {
				rainSound.GetComponent<AudioSource>().volume = ((float)timeToFade/300f) * 0.3f;
			}


			if (timeToFade <= 0) {
				fadingInRainSound = false;
				fadingOutRainSound = false;
			}
		}
	}

	void changeWeather() {
		float shouldChange = Random.Range (0, 3);
		if (shouldChange < 1) {
			if (isRaining) {
				//topdownLighting.GetComponent<Light>().color = new Color(0.5f, 0.5f, 0.5f);
				//angledLighting.GetComponent<Light>().color = new Color(0.5f, 0.5f, 0.5f);
				goldLighting.GetComponent<Light>().enabled = true;
				rainParticles.GetComponent<ParticleSystem>().Stop();

				isRaining = false;
				//rainSound.GetComponent<AudioSource>().Stop();
				fadingOutRainSound = true;
				timeToFade = 300;

			} else {
				//topdownLighting.GetComponent<Light>().color = new Color(0.25f, 0.25f, 0.25f);
				//angledLighting.GetComponent<Light>().color = new Color(0.25f, 0.25f, 0.25f);
				goldLighting.GetComponent<Light>().enabled = false;
				rainParticles.GetComponent<ParticleSystem>().Play();

				isRaining = true;
				rainSound.GetComponent<AudioSource>().Play();
				fadingInRainSound = true;
				timeToFade = 300;
			}
		}

		if (isRaining) {
			float shouldStrikeLightning = Random.Range (0, 4);
			if (shouldStrikeLightning < 1) {
				Instantiate (lightning, new Vector3(2, 0, -10), transform.rotation);
			}
		}

		timeToChange = 300;
	}
}
