using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    [SerializeField] float fadeDuration = 1f;
    [SerializeField] float displayImageDuration = 2f;
    [SerializeField] GameObject player;
    [SerializeField] CanvasGroup exitBackgroundImageCanvasGroup;
    [SerializeField] AudioSource exitAudio;
    [SerializeField] CanvasGroup catchBackgroundImageCanvasGroup;
    [SerializeField] AudioSource caughtAudio;
    bool _isPlayerAtExit = false;
    bool _isPlayerCaught = false;
    bool _hasAudioPlayed = false;
    float _timer = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            _isPlayerAtExit = true;
        }
    }

    public void CaughtPlayer()
    {
        _isPlayerCaught = true;
    }

    private void Update()
    {
        if (_isPlayerAtExit)
        {
            EndLevel(exitBackgroundImageCanvasGroup, false, exitAudio);
        } 
        else if (_isPlayerCaught)
        {
            EndLevel(catchBackgroundImageCanvasGroup, true, caughtAudio);
        }
    }

    void EndLevel(CanvasGroup imageCanvasGroup, bool doRestart, AudioSource audioSource)
    {
        _timer += Time.deltaTime;

        imageCanvasGroup.alpha = _timer / fadeDuration;

        if(_timer > fadeDuration + displayImageDuration)
        {
            if (doRestart)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                Application.Quit();
            }
        }

        if(_hasAudioPlayed == false)
        {
            audioSource.Play();
            _hasAudioPlayed = true;
        }
    }
}
