using UnityEngine;

namespace Package.Low_Poly_Modular_Terrain_Pack.Bonus_Assets.Scripts
{
	public class ModularTerrainCloudsControl : MonoBehaviour {

		//Range for min/max values of variable
		[Range(-10f, 10f)]
		public float cloudsMoveSpeed_x, cloudsMoveSpeed_z;

		// Clouds Movement
		void Update () {
			gameObject.transform.Translate (cloudsMoveSpeed_x * Time.deltaTime, 0f, cloudsMoveSpeed_z * Time.deltaTime);
		}
	}
}
