using UnityEngine;
using Unity.Cinemachine;
using System.Collections;

namespace Chapter.Observer
{
    public class CameraController : Observer
    {
        PlayerController playerController;
        CinemachineCamera playerCamera;
        CinemachineBasicMultiChannelPerlin noise;
        bool isShaking;

        void Awake()
        {
            playerCamera = gameObject.GetComponent<CinemachineCamera>();
            noise = playerCamera.GetComponentInChildren<CinemachineBasicMultiChannelPerlin>();
        }

        void Update()
        {
            if (isShaking)
            {
                StartCoroutine(ShakeTime());
            }
        }

        public override void Notify(Subject subject)
        {
            if (!playerController)
            {
                playerController = subject.GetComponent<PlayerController>();
            }

            if (playerController)
            {
                isShaking = playerController.GetIsShaking();
            }
        }

        IEnumerator ShakeTime()
        {
            noise.AmplitudeGain = 1.0f;
            noise.FrequencyGain = 5.0f;
            Debug.Log("Shaking!");
            yield return new WaitForSeconds(0.4f);
            noise.AmplitudeGain = 0f;
            noise.FrequencyGain = 0f;
            Debug.Log("Stopped shaking!");
            isShaking = false;
        }
    }
}