﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// SwatchyRenderer
//  Applies a SwatchyColor in OnEnable to the connected Renderer's material.
//  Does this by setting "_Color" on the renderer's Material Property Block
namespace Swatchy {
	[RequireComponent(typeof(Renderer))]
	public class SwatchyRenderer : SwatchyColorApplier {

		[HideInInspector]
		public Renderer swatchingRenderer;

		static MaterialPropertyBlock mpb;
		static int colorShaderId;

		public override void Apply() {
			if (mpb == null) {
				mpb = new MaterialPropertyBlock();
				colorShaderId = Shader.PropertyToID("_Color");
			}
			if (swatchingRenderer == null) {
				swatchingRenderer = GetComponent<Renderer>();
			}
			mpb.SetColor(colorShaderId, swatchyColor.color);
			swatchingRenderer.SetPropertyBlock(mpb);
		}
	}
}