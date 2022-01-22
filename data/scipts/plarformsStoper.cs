using System;
using System.Collections;
using System.Collections.Generic;
using Unigine;

[Component(PropertyGuid = "35deec1fd9dc4af2641d2da9679c9af406f409c3")]
public class plarformsStoper : Component
{
	[ShowInEditor]
	[Parameter(Tooltip = "Manager")]
	public LevelManager manager;

	private void Init()
	{
		if (manager == null) {
			manager = ComponentSystem.FindComponentInWorld<LevelManager>();
		}
	}
	
	private void Update()
	{
		List<Node> intersected = new List<Node>();
		if (World.GetIntersection(node.WorldBoundBox, Node.TYPE.OBJECT_MESH_STATIC, intersected)) {
			foreach(Node nd in intersected) {
				platform plat = nd.GetComponent<platform>();
				if (plat != null) {
					plat.StopTimer();
				}
			}
		}
		if (node.WorldPosition[2] < -50) {
			manager.Loose();
		}
	}
}