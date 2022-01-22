using System;
using System.Collections;
using System.Collections.Generic;
using Unigine;

[Component(PropertyGuid = "69fe93426e7ab9b9e1bb17c4908b4053573d4996")]
public class MoldSpowner : Component
{
	[ShowInEditor]
	[Parameter(Tooltip = "molds")]
	public List<Node> molds;
	[ShowInEditor]
	[Parameter(Tooltip = "player")]
	public Node player;

	private double diff;
	private double lastPos;
	System.Random rand;

	private void Init()
	{
		lastPos = node.WorldPosition[1];
		diff = lastPos - player.WorldPosition[1];
		rand = new System.Random();
		spawnMold();
		node.WorldPosition = new vec3(node.WorldPosition[0], player.WorldPosition[1]+2*diff + 8, node.WorldPosition[2]);
		spawnMold();
		lastPos = node.WorldPosition[1];
	}
	
	private void Update()
	{
		node.WorldPosition = new vec3(node.WorldPosition[0], player.WorldPosition[1]+2*diff + 20, node.WorldPosition[2]);
		if (node.WorldPosition[1] - lastPos > diff + 8) {
			spawnMold();
			lastPos = node.WorldPosition[1];
		}
		
	}

	private void spawnMold() {
		Node sMold = molds[rand.Next(molds.Count)].Clone();
		sMold.WorldPosition = node.WorldPosition;
		sMold.Enabled = true;
	}
}