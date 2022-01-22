using System;
using System.Collections;
using System.Collections.Generic;
using Unigine;
using System.Timers;

[Component(PropertyGuid = "a2739bbcc1b6c3eb06b9884ecfc7f35537d72cb0")]
public class platform : Component
{
	[ShowInEditor]
	[Parameter(Tooltip = "Timer before doom")]
	public int doomClock = 30;

	[ShowInEditor]
	[Parameter(Tooltip = "small bonus")]
	public Node smallBonus;

	[ShowInEditor]
	[Parameter(Tooltip = "big bonus")]
	public Node bigBonus;

	public float fallSpeed = 6.0f;
	private bool _fall = false;
	private bool _doom = false;
	private System.Timers.Timer _timer;
	System.Random rand;
	private void Init()
	{
		_timer =  new System.Timers.Timer(doomClock*1000);
		rand = new System.Random();
		double chance = rand.NextDouble();
		if (chance > 0.4) {
			Node bon;
			if (chance > 0.8) {
				bon = bigBonus.Clone();
			} else {
				bon = smallBonus.Clone();
			}
			bon.WorldPosition = node.WorldPosition;
			bon.Enabled = true;
		}
	}
	
	private void Update()
	{
		if (_fall) {
			node.WorldPosition += Unigine.vec3.DOWN * fallSpeed * Game.IFps;
		}
		if (_doom) {
			Shake();
		}

		if (node.WorldPosition[2] < -100) {
			node.Enabled = false;
		}
	}

	public void StartTimer() {
		_timer =  new System.Timers.Timer(doomClock*1000);
		_timer.Elapsed += TimerRunOut;
		_doom = true;
		_timer.Start();
	}

	private int shake = 4;
	private void Shake() {
		node.Rotate(0, shake, 0);
		shake *= -1;
	}

	private void TimerRunOut(System.Object source, ElapsedEventArgs e) {
		_fall = _doom;
	}

	public void StopTimer() {
		_doom = false;
		if (shake < 0) {
			node.Rotate(0, shake, 0);
			shake *= -1;
		}
		_timer.Stop();
	}
}