using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnding : MonoBehaviour
{
    [SerializeField] float fadeDuration = 1f;
    [SerializeField] float displayImageDuration = 2f;
    [SerializeField] GameObject player;
    [SerializeField] CanvasGroup exitBackgroundImageCanvasGroup;
    bool _isPlayerAtExit = false;
    float _timer = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            _isPlayerAtExit = true;
        }
    }

    private void Update()
    {
        if (_isPlayerAtExit)
        {
            EndLevel();
        }
    }

    void EndLevel()
    {
        _timer += Time.deltaTime;

        exitBackgroundImageCanvasGroup.alpha = _timer / fadeDuration;

        if(_timer > fadeDuration + displayImageDuration)
        {
            Application.Quit();
        }
    }
}
