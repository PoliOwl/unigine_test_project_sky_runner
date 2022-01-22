using System;
using System.Collections;
using System.Collections.Generic;
using Unigine;

[Component(PropertyGuid = "c7a20a9df9390b58ba7196d7b14c464a7e8a0121")]
public class KillWall : Component
{
	[ShowInEditor]
	[Parameter(Tooltip = "player")]
	public Node player;
	private double diff;
	private WorldTrigger trigger;
	private void Init()
	{
		trigger = node as WorldTrigger;
		if (trigger != null)
			trigger.AddEnterCallback(Enter);
		diff = node.WorldPosition[1] - player.WorldPosition[1];

	}
	
	private void Update()
	{
		node.WorldPosition = new vec3(node.WorldPosition[0], player.WorldPosition[1]+diff, node.WorldPosition[2]);
		
	}

	void Enter(Node target)
	{
		target.Enabled = false;
	}
}