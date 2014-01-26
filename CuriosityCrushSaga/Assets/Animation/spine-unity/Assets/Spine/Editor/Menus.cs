/******************************************************************************
 * Spine Runtimes Software License
 * Version 2
 * 
 * Copyright (c) 2013, Esoteric Software
 * All rights reserved.
 * 
 * You are granted a perpetual, non-exclusive, non-sublicensable and
 * non-transferable license to install, execute and perform the Spine Runtimes
 * Software (the "Software") solely for internal use. Without the written
 * permission of Esoteric Software, you may not (a) modify, translate, adapt or
 * otherwise create derivative works, improvements of the Software or develop
 * new applications using the Software or (b) remove, delete, alter or obscure
 * any trademarks or any copyright, trademark, patent or other intellectual
 * property or proprietary rights notices on or in the Software, including
 * any copy thereof. Redistributions in binary or source form must include
 * this license and terms. THIS SOFTWARE IS PROVIDED BY ESOTERIC SOFTWARE
 * "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED
 * TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR
 * PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL ESOTERIC SOFTARE BE LIABLE FOR ANY
 * DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
 * (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
 * LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
 * ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
 * (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF
 * THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 *****************************************************************************/

using System;
using System.IO;
using UnityEditor;
using UnityEngine;
using Spine;

public class SpineEditor {
	[MenuItem("Assets/Create/Spine Atlas")]
	static public void CreateAtlas () {
		CreateAsset<AtlasAsset>("New Atlas");
	}
	
	[MenuItem("Assets/Create/Spine SkeletonData")]
	static public void CreateSkeletonData () {
		CreateAsset<SkeletonDataAsset>("New SkeletonData");
	}
	
	static private void CreateAsset <T> (String path) where T : ScriptableObject {
		try {
			path = Path.GetDirectoryName(AssetDatabase.GetAssetPath(Selection.activeObject)) + "/" + path;
		} catch (Exception) {
			path = "Assets/" + path;
		}
		ScriptableObject asset = ScriptableObject.CreateInstance<T>();
		AssetDatabase.CreateAsset(asset, path + ".asset");
		AssetDatabase.SaveAssets();
		EditorUtility.FocusProjectWindow();
		Selection.activeObject = asset;
	}

	[MenuItem("GameObject/Create Other/Spine SkeletonComponent")]
	static public void CreateSkeletonComponentGameObject () {
		GameObject gameObject = new GameObject("New SkeletonComponent", typeof(SkeletonComponent));
		EditorUtility.FocusProjectWindow();
		Selection.activeObject = gameObject;
	}

	[MenuItem("GameObject/Create Other/Spine SkeletonAnimation")]
	static public void CreateSkeletonAnimationGameObject () {
		GameObject gameObject = new GameObject("New SkeletonAnimation", typeof(SkeletonAnimation));
		EditorUtility.FocusProjectWindow();
		Selection.activeObject = gameObject;
	}
	
	[MenuItem("Component/Spine SkeletonComponent")]
	static public void CreateSkeletonComponent () {
		Selection.activeGameObject.AddComponent(typeof(SkeletonComponent));
	}
	
	[MenuItem("Component/Spine SkeletonAnimation")]
	static public void CreateSkeletonAnimation () {
		Selection.activeGameObject.AddComponent(typeof(SkeletonAnimation));
	}
	
	[MenuItem("Component/Spine SkeletonComponent", true)]
	static public bool ValidateCreateSkeletonComponent () {
		return Selection.activeGameObject != null
			&& Selection.activeGameObject.GetComponent(typeof(SkeletonComponent)) == null
			&& Selection.activeGameObject.GetComponent(typeof(SkeletonAnimation)) == null;
	}

	[MenuItem("Component/Spine SkeletonAnimation", true)]
	static public bool ValidateCreateSkeletonAnimation () {
		return ValidateCreateSkeletonComponent();
	}
}