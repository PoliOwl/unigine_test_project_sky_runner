using System;
using System.Collections;
using System.Collections.Generic;
using Unigine;

[Component(PropertyGuid = "c359ea2bd97ff98ea43b3395338aeff0a486c28f")]
public class WinPlatform : Component
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
				plarformsStoper plat = nd.GetComponent<plarformsStoper>();
				if (plat != null) {
					manager.Win();
				}
			}
		}
	}
}