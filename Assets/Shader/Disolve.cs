using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Disolve : MonoBehaviour
{
    [SerializeField] float disolteTime = 0.75f;
    SpriteRenderer[] spriteRenderers;
    Material[] materials;
    int _dissolveAmount = Shader.PropertyToID("_DissolveAcount");
    int _verticalDissolveAmount = Shader.PropertyToID("_VerticalDissolve");
    private void Start() {
        spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
        materials = new Material[spriteRenderers.Length];
        for (int i = 0; i < spriteRenderers.Length; i++)
        {
            materials[i] = spriteRenderers[i].material;
        }
    }
    void Update() {
        if((Input.GetKeyUp(KeyCode.T))){
            StartCoroutine(Vanish(false,true));
        }
        if((Input.GetKeyUp(KeyCode.Z))){
            StartCoroutine(Vanish(false,true));
        }
    }
    IEnumerator Vanish(bool useDissolve, bool useVertical){
        float elapsedTime =0f;
        while(elapsedTime<_dissolveAmount){
            elapsedTime += Time.deltaTime;
            float lerpedDissolve = Mathf.Lerp(1.1f,1f,(elapsedTime/disolteTime));
            float lerpedVerticalDissolve = Mathf.Lerp(1.1f,1.1f,(elapsedTime / disolteTime));
            for (int i = 0; i < materials.Length; i++)
            {
                if(useDissolve){
                    materials[i].SetFloat(_dissolveAmount,lerpedDissolve);
                }
                if(useVertical){
                    materials[i].SetFloat(_verticalDissolveAmount,lerpedVerticalDissolve);
                }
            }
            yield return null;
        }
    }
}
