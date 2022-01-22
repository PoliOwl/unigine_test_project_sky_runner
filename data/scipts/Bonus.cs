using System;
using System.Collections;
using System.Collections.Generic;
using Unigine;

[Component(PropertyGuid = "67c5131be4b0adbe362f7a05d1f323a04099827f")]
public class Bonus : Component
{
	[ShowInEditor]
	[Parameter(Tooltip = "Points")]
	public int points = 10;

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
				plarformsStoper plat = nd.GetComponent<plarformsStoper>();
				if (plat != null) {
					manager.addScore(points);
					node.Enabled = false;
				}
			}
		}
	}
}