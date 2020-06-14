using UnityEngine;

public class StaticEffect : MonoBehaviour
{

    private static string MATERIAL_INTENSITY_PARAM = "_Intensity";

    public float MaxIntensityDuration = 2f;
    public float IntensityDecayDuration = 0.5f;

    private Material _material;

    private float _maxIntensityElapsed;
    private float _intensityDecayElapsed;

    void Awake()
    {
        this._material = this.GetComponent<SpriteRenderer>().material;
    }

    void Start() 
    {
        // Prevent the sprite from starting in a static phase by skipping to the end
        // of the animation.
        this._maxIntensityElapsed = MaxIntensityDuration;
        this._intensityDecayElapsed = IntensityDecayDuration;    
    }

    void OnDestroy() 
    {
        // Clean up our material reference
        Destroy(this._material);    
    }

    void Update()
    {
        // Restart the effect
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this._maxIntensityElapsed = 0f;
            this._intensityDecayElapsed = 0f;
        }
        
        // Calculate the intensity based on the phase of the animation
        float intensity; 

        // Max Static Intensity phase
        if (this._maxIntensityElapsed < MaxIntensityDuration)
        {
            this._maxIntensityElapsed += Time.deltaTime;
            intensity = 1f;
        }
        // Decay phase
        else if (this._intensityDecayElapsed < IntensityDecayDuration)
        {
            this._intensityDecayElapsed += Time.deltaTime;
            intensity = Mathf.Lerp(1f, 0f, this._intensityDecayElapsed / IntensityDecayDuration);
        }
        // Normal Rendering, or Off phase
        else
        {
            intensity = 0f;
        }

        this._material.SetFloat(MATERIAL_INTENSITY_PARAM, intensity);
    }
}
