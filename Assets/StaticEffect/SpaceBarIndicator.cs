using UnityEngine;
using UnityEngine.UI;

public class SpaceBarIndicator : MonoBehaviour
{
    
    private CanvasGroup _canvas;

    void Awake()
    {
        this._canvas = this.GetComponent<CanvasGroup>();
    }

    void Update()
    {
        this._canvas.alpha = Input.GetKey(KeyCode.Space) ? 1f : 0f;        
    }
}
