﻿using UnityEngine;


/*--------------------------------------------------------------------------------------*/
/*																						*/
/*	GameEvent: Abstract class for Game Events for the GameEventsManager				    */
/*																						*/
/*--------------------------------------------------------------------------------------*/
public abstract class GameEvent 
{
   
}


public class MouseDown : GameEvent{
	public Vector3 mousePos;
	public MouseDown(Vector3 mousePos_){
		mousePos = mousePos_;
	}
}

public class MouseUp : GameEvent
{
    public Vector3 mousePos;
    public MouseUp(Vector3 mousePos_)
    {
        mousePos = mousePos_;
    }
}

public class MouseMove : GameEvent
{
    public Vector3 mousePos;
    public MouseMove(Vector3 mousePos_)
    {
        mousePos = mousePos_;
    }
}

public class TouchMove : GameEvent{
	public Touch touch;
	public TouchMove(Touch touch_){
		touch = touch_;
	}
}

public class TouchDown : GameEvent
{
    public Touch touch;

    public TouchDown(Touch touch_)
    {
        touch = touch_;
    }
}

public class TouchUp : GameEvent
{
    public Touch touch;

    public TouchUp(Touch touch_)
    {
        touch = touch_;
    }
}

public class ButtonPressed : GameEvent
{
    public readonly string button;
    public readonly int playerNum;
    public ButtonPressed(string _button, int _playerNum)
    {
        button = _button;
        playerNum = _playerNum;
    }
}

public class TriggerAxisEvent : GameEvent
{
    public readonly float rightAxis;
    public readonly float leftAxis;
    public readonly int playerNum;
    public TriggerAxisEvent(float _rightAxis, float _leftAxis, int _playerNum)
    {
        rightAxis = _rightAxis;
        leftAxis = _leftAxis;
        playerNum = _playerNum;
    }
}

public class LeftStickAxisEvent : GameEvent
{
    public readonly Vector2 leftStickAxis;
    public readonly int playerNum;
    public LeftStickAxisEvent(Vector2 _leftStickAxis, int _playerNum)
    {
        leftStickAxis = _leftStickAxis;
        playerNum = _playerNum;
    }
}

public class DPadAxisEvent : GameEvent
{
    public readonly IntVector2 dPadAxis;
    public readonly int playerNum;
    public DPadAxisEvent(IntVector2 _dPadAxis, int _playerNum)
    {
        dPadAxis = _dPadAxis;
        playerNum = _playerNum;
    }
}

public class RightStickAxisEvent : GameEvent
{
    public readonly Vector2 rightStickAxis;
    public readonly int playerNum;
    public RightStickAxisEvent(Vector2 _rightStickAxis, int _playerNum)
    {
        rightStickAxis = _rightStickAxis;
        playerNum = _playerNum;
    }
}



public class StartTimerEvent : GameEvent
{
    public readonly bool decrementTime;
    public StartTimerEvent(bool _decrementTime)
    {
        decrementTime = _decrementTime;
    }
}

public class TenSecondsLeftEvent : GameEvent
{
    public readonly bool tenSecondsLeft;
    public TenSecondsLeftEvent(bool _tenSecondsLeft)
    {
        tenSecondsLeft = _tenSecondsLeft;
    }
}

public class TimeIsOverEvent : GameEvent
{
    public readonly Timer timer;
    public TimeIsOverEvent(Timer _timer)
    {
        timer = _timer;
    }
}

public class StopTimerEvent : GameEvent
{

}


public class KeyPressedEvent : GameEvent
{
    public readonly KeyCode key;
    public KeyPressedEvent(KeyCode _key)
    {
        key = _key;
    }
}

public class Reset : GameEvent { }