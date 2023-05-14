using UnityEngine;

namespace Package.Low_Poly_Modular_Terrain_Pack.Bonus_Assets.Scripts
{
	public class ModularTerrainSunControl : MonoBehaviour {

		//Range for min/max values of variable
		[Range(-10f, 10f)]
		public float sunRotationSpeed_x, sunRotationSpeed_y;

		// Sun Movement
		void Update () {
			gameObject.transform.Rotate (sunRotationSpeed_x * Time.deltaTime, sunRotationSpeed_y * Time.deltaTime, 0);
		}
	}
}
