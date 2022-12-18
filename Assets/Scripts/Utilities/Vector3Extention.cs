namespace Utilities
{
	using UnityEngine;

	public static class Vector3Extention
	{
		public static Vector3 SetX(Vector3 vector3, float x)
		{
			return new Vector3(x, vector3.y, vector3.z);
		}

		public static Vector3 SetY(Vector3 vector3, float y)
		{
			return new Vector3(vector3.x, y, vector3.z);
		}

		public static Vector3 SetZ(Vector3 vector3, float z)
		{
			return new Vector3(vector3.x, vector3.y, z);
		}

		public static Vector3 SetXY(Vector3 vector3, float x, float y)
		{
			return new Vector3(x, y, vector3.z);
		}

		public static Vector3 SetXZ(Vector3 vector3, float x, float z)
		{
			return new Vector3(x, vector3.y, z);
		}

		public static Vector3 SetYZ(Vector3 vector3, float y, float z)
		{
			return new Vector3(vector3.x, y, z);
		}
	}
}
