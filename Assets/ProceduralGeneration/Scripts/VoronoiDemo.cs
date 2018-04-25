using UnityEngine;
using System.Collections.Generic;
using Delaunay;
using Delaunay.Geo;

public class VoronoiDemo : MonoBehaviour
{
	
	//[SerializeField]
	private int
		m_pointCount = 40;

	private List<Vector2> m_points;
	private float m_mapWidth = 150;
	private float m_mapHeight = 200;
	private List<LineSegment> m_edges = null;


	void Awake ()
	{
		Random.InitState (452);
		Demo ();

		GameObject thePlayer = GameObject.Find("Generator");
		Generator playerScript = thePlayer.GetComponent<Generator>();
		playerScript.floorMin = new Vector3 (0,0,0);
		playerScript.floorMax = new Vector3 (m_mapWidth*(float)1,0,m_mapHeight*(float)1);
		for(int i=0;i<m_pointCount;i++){
			playerScript.centers.Add (new Vector3(m_points [i].x,0,m_points [i].y));
		}
		for(int i=0;i<m_edges.Count;i++){
			playerScript.edges.Add (new Vector3 (m_edges.ToArray()[i].p0.Value.x, 0, m_edges.ToArray()[i].p0.Value.y));
			playerScript.edges.Add (new Vector3 (m_edges.ToArray()[i].p1.Value.x, 0, m_edges.ToArray()[i].p1.Value.y));
		}

	}

	private void Demo ()
	{
				
		List<uint> colors = new List<uint> ();
		m_points = new List<Vector2> ();
			
		for (int i = 0; i < m_pointCount; i++) {
			colors.Add (0);
			m_points.Add (new Vector2 (
					UnityEngine.Random.Range (0, m_mapWidth),
					UnityEngine.Random.Range (0, m_mapHeight))
			);
		}
		Delaunay.Voronoi v = new Delaunay.Voronoi (m_points, colors, new Rect (0, 0, m_mapWidth, m_mapHeight));
		m_edges = v.VoronoiDiagram ();
	}

	void OnDrawGizmos ()
	{
		
		Gizmos.color = Color.red;
		if (m_points != null) {
			for (int i = 0; i < m_points.Count; i++) {
				Gizmos.DrawSphere (new Vector3(m_points [i].x,0,m_points [i].y), 0.2f);
			}
		}


	}
}