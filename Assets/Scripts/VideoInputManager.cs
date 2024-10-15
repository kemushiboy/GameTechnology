using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class VideoInputManager : MonoBehaviour
{

	[SerializeField] private RenderTexture[] renderTextures;
	private WebCamTexture[] webCamTextures;


	WebCamDevice[] devices;

	void Start()
	{
		//配列確保
		webCamTextures = new WebCamTexture[renderTextures.Length];

		// デバイスの一覧を取得
		devices = WebCamTexture.devices;

		//ドロップダウンにデバイス一覧を追加
		

		if (devices.Length > 0)
		{

			for (int i = 0; i < webCamTextures.Length; i++)
			{
				string cameraName = devices[i].name;
	
				// WebCamTextureを初期化してカメラ映像を開始
				webCamTextures[i] = new WebCamTexture(cameraName);

				// カメラ映像の再生を開始
				webCamTextures[i].Stop();
				webCamTextures[i].Play();	

				//負荷軽減
				//webCamTextures[i].Pause();

			}
		}
		else
		{
			Debug.Log("カメラが見つかりませんでした。");
		}
	}

	

	public void ChangeWebCam0Device( int deviceIndex )
	{
		ChangeDevice(deviceIndex, 0);
	}

	public void ChangeWebCam1Device(int deviceIndex)
	{
		ChangeDevice(deviceIndex, 1);
	}

	public void ChangeWebCam2Device(int deviceIndex)
	{
		ChangeDevice(deviceIndex, 2);
	}

	public void ChangeWebCam3Device(int deviceIndex)
	{
		ChangeDevice(deviceIndex, 3);
	}

	public void ToggleWebCam(int index, bool play)
	{
		if(play && !webCamTextures[index].isPlaying)
		{
			webCamTextures[index].Play();
			
		}

		else if(!play && webCamTextures[index].isPlaying) 
		{
			//webCamTextures[index].Pause();
		}
	}

	public void UpdateFrameCoroutine(int index)
	{
		StartCoroutine(UpdateFrame(index));
	}
	 IEnumerator UpdateFrame(int index)
	{
		webCamTextures[index].Play();
		yield return new WaitForNextFrameUnit();
		webCamTextures[index].Pause();

	}



	 void ChangeDevice(int deviceIndex , int webCamIndex)
	{
		  if (webCamTextures[webCamIndex] != null && webCamTextures[webCamIndex].isPlaying)
        {
            webCamTextures[webCamIndex].Stop(); // 既に再生中なら停止
        }

        // 新しいWebCamTextureを初期化して再生開始
        webCamTextures[webCamIndex] = new WebCamTexture(devices[deviceIndex].name);
		webCamTextures[webCamIndex].Play();

	
	}

	private void Update()
	{
		

		for (int i = 0; i < webCamTextures.Length; i++)

			if (webCamTextures[i] != null && webCamTextures[i].isPlaying)
			{
				// WebCamTextureの映像をRenderTextureに描画
				Graphics.Blit(webCamTextures[i], renderTextures[i]);
			}
	}

	void OnDestroy()
	{
		// カメラの映像再生を停止
		foreach (var webCamTexture in webCamTextures)
		{
			if (webCamTexture != null)
			{
				webCamTexture.Stop();
			}
		}
	}
}
