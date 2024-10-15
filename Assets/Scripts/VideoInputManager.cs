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
		//�z��m��
		webCamTextures = new WebCamTexture[renderTextures.Length];

		// �f�o�C�X�̈ꗗ���擾
		devices = WebCamTexture.devices;

		//�h���b�v�_�E���Ƀf�o�C�X�ꗗ��ǉ�
		

		if (devices.Length > 0)
		{

			for (int i = 0; i < webCamTextures.Length; i++)
			{
				string cameraName = devices[i].name;
	
				// WebCamTexture�����������ăJ�����f�����J�n
				webCamTextures[i] = new WebCamTexture(cameraName);

				// �J�����f���̍Đ����J�n
				webCamTextures[i].Stop();
				webCamTextures[i].Play();	

				//���׌y��
				//webCamTextures[i].Pause();

			}
		}
		else
		{
			Debug.Log("�J������������܂���ł����B");
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
            webCamTextures[webCamIndex].Stop(); // ���ɍĐ����Ȃ��~
        }

        // �V����WebCamTexture�����������čĐ��J�n
        webCamTextures[webCamIndex] = new WebCamTexture(devices[deviceIndex].name);
		webCamTextures[webCamIndex].Play();

	
	}

	private void Update()
	{
		

		for (int i = 0; i < webCamTextures.Length; i++)

			if (webCamTextures[i] != null && webCamTextures[i].isPlaying)
			{
				// WebCamTexture�̉f����RenderTexture�ɕ`��
				Graphics.Blit(webCamTextures[i], renderTextures[i]);
			}
	}

	void OnDestroy()
	{
		// �J�����̉f���Đ����~
		foreach (var webCamTexture in webCamTextures)
		{
			if (webCamTexture != null)
			{
				webCamTexture.Stop();
			}
		}
	}
}
