using System;
using System.Collections;
using System.Collections.Generic;
using Unigine;

[Component(PropertyGuid = "7b968fb7893629aada62cd01b63ac26ce36ddadb")]
public class platformKiller : Component
{
	private void Init()
	{
		// write here code to be called on component initialization
		
	}
	
	private void Update()
	{
				List<Node> intersected = new List<Node>();
		if (World.GetIntersection(node.WorldBoundBox, Node.TYPE.OBJECT_MESH_STATIC, intersected)) {
			foreach(Node nd in intersected) {
				platform plat = nd.GetComponent<platform>();
				if (plat != null) {
					plat.StartTimer();
				}
			}
		}
	}
}