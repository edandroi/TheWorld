using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class InputManager
{
    private Touch[] lastFrameTouches;
    private Vector3 lastMousePos;
    static private KeyCode[] validKeyCodes;

    public InputManager()
    {
        if (validKeyCodes != null) return;
        validKeyCodes = (KeyCode[])System.Enum.GetValues(typeof(KeyCode));
    }

    //  BUG: Button Presses Register twice for both players
    public void GetInput()
    {
        //if (Input.GetButtonDown("Reset")) Services.EventManager.Fire(new Reset());
		for (int i = 0; i < Input.touches.Length; i++)
        {
			Touch touch = Input.touches [i];
            switch (touch.phase)
            {
			case TouchPhase.Began:
				Services.EventManager.Fire (new TouchDown (touch));
				break;
			case TouchPhase.Moved:
				Services.EventManager.Fire (new TouchMove (touch));
				break;
			case TouchPhase.Stationary:
				break;
			case TouchPhase.Ended:
				Touch touchLastFrame = GetLastFrameTouch (touch.fingerId);
				if (touchLastFrame.phase != TouchPhase.Ended) {
					Services.EventManager.Fire (new TouchUp (touch));
                    }
                    break;
			case TouchPhase.Canceled:
				break;
			default:
				break;
            }
        }
        if (Input.GetMouseButtonDown(0)) {
            Services.EventManager.Fire(new MouseDown(Input.mousePosition));
            lastMousePos = Input.mousePosition;
        }

        if (Input.GetMouseButton(0) && Input.mousePosition != lastMousePos)
        {
            Services.EventManager.Fire(new MouseMove(Input.mousePosition));
            lastMousePos = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            Services.EventManager.Fire(new MouseUp(Input.mousePosition));
        }
        //if (Services.UIManager != null)
        //	Services.UIManager.UpdateTouchCount (Input.touches);
    }

    private KeyCode FetchKey()
    {
        for (int i = 0; i < validKeyCodes.Length; i++)
        {
            if (Input.GetKeyDown((KeyCode)i))
            {
                return (KeyCode)i;
            }
        }

        return KeyCode.None;
    }

    public void Update()
    {
        if (Input.anyKey)
        {
            Services.EventManager.Fire(new KeyPressedEvent(FetchKey()));
        }

        GetInput();
        lastFrameTouches = Input.touches;
    }

	Touch GetLastFrameTouch(int id){
		for (int i = 0; i < lastFrameTouches.Length; i++) {
			if (lastFrameTouches [i].fingerId == id)
				return lastFrameTouches [i];
		}
		return new Touch ();
	}


}
