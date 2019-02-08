using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class StructureScript : MonoBehaviour {

	public bool hitByRay;
	bool hitByRayControlVariable;
	int transparent = 2450;
	int opaque = 2500;
	float opaqueAlpha = 1.0f;
	public float transparentAlpha = 0.3f;
	Color color;
	void Start(){
		this.gameObject.layer = LayerMask.NameToLayer("Structure");
		color = GetComponent<Renderer>().material.GetColor("_Color");
	}
	void LateUpdate(){
		if(hitByRay != hitByRayControlVariable){
			hitByRayControlVariable = hitByRay;
			if(hitByRay){
				SwitchBlendMode(GetComponent<Renderer>().material, 3);
				GetComponent<Renderer>().material.renderQueue = this.transparent;
				color.a = transparentAlpha;
			}else{
				SwitchBlendMode(GetComponent<Renderer>().material, 0);
				GetComponent<Renderer>().material.renderQueue = this.opaque;
				color.a = opaqueAlpha;
			}
			GetComponent<Renderer>().material.SetColor("_Color", color);
		}
		hitByRay = false;
	}
	public static void SwitchBlendMode(Material material, int blendMode)
	{
		switch (blendMode)
		{
			case 0:
				material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
				material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
				material.SetInt("_ZWrite", 1);
				material.DisableKeyword("_ALPHATEST_ON");
				material.DisableKeyword("_ALPHABLEND_ON");
				material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
				material.renderQueue = -1;
				break;
			case 1:
				material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
				material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
				material.SetInt("_ZWrite", 1);
				material.EnableKeyword("_ALPHATEST_ON");
				material.DisableKeyword("_ALPHABLEND_ON");
				material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
				material.renderQueue = 2450;
				break;
			case 2:
				material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
				material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
				material.SetInt("_ZWrite", 0);
				material.DisableKeyword("_ALPHATEST_ON");
				material.EnableKeyword("_ALPHABLEND_ON");
				material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
				material.renderQueue = 3000;
				break;
			case 3:
				material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
				material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
				material.SetInt("_ZWrite", 0);
				material.DisableKeyword("_ALPHATEST_ON");
				material.DisableKeyword("_ALPHABLEND_ON");
				material.EnableKeyword("_ALPHAPREMULTIPLY_ON");
				material.renderQueue = 3000;
				break;
		}
	}
}

