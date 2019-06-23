﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VirtualJoystick : MonoBehaviour, IBeginDragHandler, 
	IDragHandler, IEndDragHandler {	

	public RectTransform thumb;
	private Vector2 originalPosition;
	private Vector2 originalThumbPosition;
	public Vector2 delta;

	void Start () {
		originalPosition = this.GetComponent<RectTransform>().localPosition;
		originalThumbPosition = thumb.localPosition;

		thumb.gameObject.SetActive(false);
		delta = Vector2.zero;
	}

	public void OnBeginDrag (PointerEventData eventData) {
		thumb.gameObject.SetActive(true);

		Vector3 worldPoint = new Vector3();
		RectTransformUtility.ScreenPointToWorldPointInRectangle(
			this.transform as RectTransform,
			eventData.position,
			eventData.enterEventCamera,
			out worldPoint);

		this.GetComponent<RectTransform>().position = worldPoint;
		thumb.localPosition = originalThumbPosition;
	}

	public void OnDrag (PointerEventData eventData) {
		Vector3 worldPoint = new Vector3();
		RectTransformUtility.ScreenPointToWorldPointInRectangle(
			this.transform as RectTransform,
			eventData.position,
			eventData.enterEventCamera,
			out worldPoint);

		thumb.position = worldPoint;
		var size = GetComponent<RectTransform>().rect.size;

		delta = thumb.localPosition;
		delta.x /= size.x / 2.0f;
		delta.y /= size.y / 2.0f;

		delta.x = Mathf.Clamp(delta.x, -1.0f, 1.0f);
		delta.y = Mathf.Clamp(delta.y, -1.0f, 1.0f);
	}

	public void OnEndDrag (PointerEventData eventData) {
		this.GetComponent<RectTransform>().localPosition = originalPosition;

		delta = Vector2.zero;
		thumb.gameObject.SetActive(false);
	}
}
