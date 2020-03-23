using System.Collections;
using UnityEngine;

public class ObjetivoManager : MonoBehaviour
{
    //current object scale
    private float _currentScale = InitScale;
    //scale max to inflate
    private const float TargetScale = 1.5f;
    //initial scale of the object
    private const float InitScale = 1f;
    //frames count
    private const int FramesCount = 100;
    //animation speed
    private const float AnimationTimeSeconds = 0.5f;
    //time to complete the animation
    private float _deltaTime = AnimationTimeSeconds / FramesCount;
    //difference between initial and target scales
    private float _dx = (TargetScale - InitScale) / FramesCount;
    //if inflate
    private bool _upScale = true;


    private void Start()
    {
        StartCoroutine(Breath());
    }

    //scale up and down the prize objects
    private IEnumerator Breath()
    {
        while (true)
        {
            //if scaling up the object
            while (_upScale)
            {
                _currentScale += _dx;
                if (_currentScale > TargetScale)
                {
                    _upScale = false;
                    _currentScale = TargetScale;
                }
                transform.localScale = Vector3.one * _currentScale;
                yield return new WaitForSeconds(_deltaTime);
            }

            //if scaling down the object
            while (!_upScale)
            {
                _currentScale -= _dx;
                if (_currentScale < InitScale)
                {
                    _upScale = true;
                    _currentScale = InitScale;
                }
                transform.localScale = Vector3.one * _currentScale;
                yield return new WaitForSeconds(_deltaTime);
            }
        }
    }

    //if collision with player
    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.tag == "Player")
        {
            
            Destroy(this.gameObject);
        }
    }
}
