using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Pathfinding {
	/// <summary>
	/// Sets the destination of an AI to the position of a specified object.
	/// This component should be attached to a GameObject together with a movement script such as AIPath, RichAI or AILerp.
	/// This component will then make the AI move towards the <see cref="target"/> set on this component.
	///
	/// See: <see cref="Pathfinding.IAstarAI.destination"/>
	///
	/// [Open online documentation to see images]
	/// </summary>
	[UniqueComponent(tag = "ai.destination")]
	[HelpURL("http://arongranberg.com/astar/docs/class_pathfinding_1_1_a_i_destination_setter.php")]
	public class AIDestinationSetter : VersionedMonoBehaviour {
		/// <summary>The object that the AI should move to</summary>
		public Transform target;
		IAstarAI ai;
		private Vector3 playerPos;
		private Dictionary<string, float> redPieces = new Dictionary<string, float>();
		private string parentPiece;

		void Start()
        {
			playerPos = transform.position;
			parentPiece = "pieces";
			for (int i = 0; i < 7; i++)
			{
				string name = parentPiece + "/piece" + (i + 1);
				GameObject piece = GameObject.Find(name);
				if (piece.gameObject.GetComponent<MeshRenderer>()) //Triangulos
				{
					redPieces.Add(name, Vector3.Distance(piece.gameObject.transform.position, playerPos));
				}
				else
				{
					if (piece.gameObject.GetComponent<SpriteRenderer>()) //Rombos
					{
						redPieces.Add(name, Vector3.Distance(piece.gameObject.transform.position, playerPos));
					}
				}
			}

			float randomNumber = Random.Range(0, redPieces.Count);
			string randomPiece = "";
			int temp = 0;
			foreach (string key in redPieces.Keys)
			{
				if (temp == randomNumber) randomPiece = key;
				temp++;
			}
			GameObject obj_piece = GameObject.Find(randomPiece);
			target = obj_piece.gameObject.transform;
			InvokeRepeating("UpdatePath", 0f, 0.2f);
		}

		void UpdatePath()
		{
			float distancetoPiece = ai.remainingDistance;
			if(distancetoPiece < 0.1)
            {
				float randomNumber = Random.Range(0, redPieces.Count);
				string randomPiece = "";
				int i = 0;
				foreach (string key in redPieces.Keys)
				{
					if (i == randomNumber) randomPiece = key;
					i++;
				}
				GameObject obj_piece = GameObject.Find(randomPiece);
				target = obj_piece.gameObject.transform;
			}
		}

		void OnEnable () {
			ai = GetComponent<IAstarAI>();
			// Update the destination right before searching for a path as well.
			// This is enough in theory, but this script will also update the destination every
			// frame as the destination is used for debugging and may be used for other things by other
			// scripts as well. So it makes sense that it is up to date every frame.
			if (ai != null) ai.onSearchPath += Update;
		}

		void OnDisable () {
			if (ai != null) ai.onSearchPath -= Update;
		}

		/// <summary>Updates the AI's destination every frame</summary>
		void Update () {
			if (target != null && ai != null) ai.destination = target.position;
		}
	}
}
